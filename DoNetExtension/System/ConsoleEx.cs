using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace System
{
    /// <summary>
    /// Provides additional methods for convenient use of <see cref="Console"/> class and applications.
    /// </summary>
    public static class ConsoleEx
    {
        public static void ConcurrentRun<TRaw, TObj>(Func<TRaw> preprocess, Func<TRaw, TObj> asyncprocess, Action<TObj> postprocess, Func<bool> @continue, Func<double> progress, bool orderedProcessing = true, int reportInterval = 1000, int maxConcurrency = 50, int maxIter = int.MaxValue, int reportTimeInterval = 600)
        {
            var beginTime = DateTime.Now;
            var lastReportTime = DateTime.Now;
            double lastProgressVal = 0;
            var dict = new ConcurrentDictionary<int, TObj>();
            var iterIndex = 0;
            var postProcessIndex = 0;
            Console.WriteLine($@"Processing start at {beginTime}");
            while (iterIndex < maxIter && @continue())
            {
                if (iterIndex - postProcessIndex < maxConcurrency)
                {
                    var rawObj = preprocess();

                    var act = new Action<int>((thisIterIdx) =>
                    {
                        var obj = asyncprocess(rawObj);
                        dict.TryAdd(thisIterIdx, obj);
                    });

                    act.BeginInvoke(iterIndex, null, null);
                    ++iterIndex;
                }
                else Thread.Sleep(500);


                if (dict.Count != 0)
                {
                    if (dict.TryRemove(orderedProcessing ? postProcessIndex : dict.Keys.First(), out var obj2))
                    {
                        do
                        {
                            postprocess(obj2);
                            ++postProcessIndex;
                        } while (dict.Count >= maxConcurrency && dict.TryRemove(orderedProcessing ? postProcessIndex : dict.Keys.First(), out obj2));
                    }

                    var secPassedSinceLastReport = lastReportTime.SecondsPassed();
                    if ((postProcessIndex % reportInterval == 0 || (secPassedSinceLastReport > reportTimeInterval && reportTimeInterval >= 0)) && postProcessIndex != 0)
                    {
                        var totalSecPassed = beginTime.SecondsPassed();
                        var progressVal = progress();
                        if (maxIter != int.MaxValue)
                        {
                            var iterProgress = (float)postProcessIndex / maxIter;
                            Console.WriteLine(
                                $@"Iter {iterIndex}/{postProcessIndex}, progress {iterProgress * 100:0.00}/{progressVal * 100:0.00}%, {totalSecPassed:0.00}s  elapsed, {(1 - iterProgress) * totalSecPassed / iterProgress:0.00}/{(1 - progressVal) * totalSecPassed / progressVal:0.00}s remain, time {DateTime.Now.ToShortTimeString()}");
                        }
                        else
                            Console.WriteLine(
                                $@"Iter {iterIndex}/{postProcessIndex}, progress {progressVal * 100:0.00}%, {totalSecPassed:0.00}s  elapsed, {(1 - progressVal) * totalSecPassed / progressVal:0.00}s remain, time {DateTime.Now.ToShortTimeString()}");
                    }
                }


            }

            Console.WriteLine($@"Finishing up post processing {iterIndex}/{postProcessIndex} ...");
            while (postProcessIndex < iterIndex)
            {
                while (dict.Count == 0) Thread.Sleep(500);
                if (dict.TryRemove(orderedProcessing ? postProcessIndex : dict.Keys.First(), out var obj2))
                {
                    postprocess(obj2);
                    ++postProcessIndex;
                }


                var secPassedSinceLastReport = lastReportTime.SecondsPassed();
                if ((postProcessIndex % reportInterval == 0 || (secPassedSinceLastReport > reportTimeInterval && reportTimeInterval >= 0)) && postProcessIndex != 0)
                {
                    var totalSecPassed = beginTime.SecondsPassed();
                    var progressVal = progress();
                    if (maxIter != int.MaxValue)
                    {
                        var iterProgress = (float)postProcessIndex / maxIter;
                        Console.WriteLine(
                            $@"Iter {iterIndex}/{postProcessIndex}, progress {iterProgress * 100:0.00}/{progressVal * 100:0.00}%, {totalSecPassed:0.00}s  elapsed, {(1 - iterProgress) * totalSecPassed / iterProgress:0.00}/{(1 - progressVal) * totalSecPassed / progressVal:0.00}s remain, time {DateTime.Now.ToShortTimeString()}");
                    }
                    else
                        Console.WriteLine(
                            $@"Iter {iterIndex}/{postProcessIndex}, progress {progressVal * 100:0.00}%, {totalSecPassed:0.00}s  elapsed, {(1 - progressVal) * totalSecPassed / progressVal:0.00}s remain, time {DateTime.Now.ToShortTimeString()}");
                }
            }


        }

        public static void Run(Action act, Func<bool> @continue, Func<double> progress, int reportInterval, int maxIter = int.MaxValue, int reportTimeInterval = 600, bool pressKeyToExit = true)
        {
            var beginTime = DateTime.Now;
            var lastReportTime = DateTime.Now;
            double lastProgressVal = 0;
            double lastIterProgressVal = 0;
            var iterIdx = 0;
            Console.WriteLine($@"Processing start at {beginTime}");
            while (iterIdx < maxIter && @continue())
            {
                act();

                var secPassedSinceLastReport = lastReportTime.SecondsPassed();
                if ((iterIdx % reportInterval == 0 || (secPassedSinceLastReport > reportTimeInterval && reportTimeInterval >= 0)) && iterIdx != 0)
                {
                    var totalSecPassed = beginTime.SecondsPassed();
                    var progressVal = progress();
                    var remainingProgressVal = 1 - progressVal;

                    if (maxIter != int.MaxValue)
                    {
                        var iterProgressVal = (double)iterIdx / maxIter;
                        var remainingIterProgressVal = 1 - iterProgressVal;
                        Console.WriteLine(
                            $@"Iter {iterIdx}/{maxIter}, progress {iterProgressVal * 100:0.00}/{progressVal * 100:0.00}%, {totalSecPassed:0.00}s elapsed, {remainingIterProgressVal * totalSecPassed / iterProgressVal:0.00}s or {remainingIterProgressVal * secPassedSinceLastReport / (iterProgressVal - lastIterProgressVal):0.00}s / {remainingProgressVal * totalSecPassed / progressVal:0.00}s or {remainingProgressVal * secPassedSinceLastReport / (progressVal - lastProgressVal):0.00}s remain");
                        lastIterProgressVal = iterProgressVal;
                    }
                    else
                        Console.WriteLine(
                        $@"Iter {iterIdx}, progress {progressVal * 100:0.00}%, {totalSecPassed:0.00}s elapsed, {remainingProgressVal * totalSecPassed / progressVal:0.00}s or {remainingProgressVal * secPassedSinceLastReport / (progressVal - lastProgressVal):0.00}s remain");

                    lastProgressVal = progressVal;

                    lastReportTime = DateTime.Now;
                }
                iterIdx += 1;
            }
            Console.WriteLine($@"Processing finished at {DateTime.Now}");
            if (pressKeyToExit) Console.ReadKey();

        }

        public static void Run(Action<int> act, Func<bool> @continue, Func<double> progress, int reportInterval, int maxIter = int.MaxValue, int reportTimeInterval = 600, bool pressKeyToExit = true)
        {
            var beginTime = DateTime.Now;
            var lastReportTime = DateTime.Now;
            double lastProgressVal = 0;
            var iterIdx = 0;
            Console.WriteLine($@"Processing start at {beginTime}");
            while (iterIdx < maxIter && @continue())
            {
                act(iterIdx);

                var secPassedSinceLastReport = lastReportTime.SecondsPassed();
                if ((iterIdx % reportInterval == 0 || (secPassedSinceLastReport > reportTimeInterval && reportTimeInterval >= 0)) && iterIdx != 0)
                {
                    var totalSecPassed = beginTime.SecondsPassed();
                    var progressVal = progress();
                    var remainingProgressVal = 1 - progressVal;

                    Console.WriteLine(
                        $@"Iter {iterIdx}, progress {progressVal * 100:0.00}%, {totalSecPassed:0.00} secs elapsed, {remainingProgressVal * totalSecPassed / progressVal:0.00} or {remainingProgressVal * secPassedSinceLastReport / (progressVal - lastProgressVal):0.00} secs remain");

                    lastProgressVal = progressVal;
                    lastReportTime = DateTime.Now;
                }
                iterIdx += 1;
            }
            Console.WriteLine($@"Processing finished at {DateTime.Now}");
            if (pressKeyToExit) Console.ReadLine();

        }

        public static void Run(Action act, Func<bool> @continue, Func<int, double> progress, int reportInterval, int maxIter = int.MaxValue)
        {
            var time = DateTime.Now;
            var iterIdx = 0;
            Console.WriteLine($@"Processing start at {time}");
            while (iterIdx < maxIter && @continue())
            {
                act();
                if (iterIdx != 0 && iterIdx % reportInterval == 0)
                {
                    var secPassed = time.SecondsPassed();
                    var progressVal = progress(iterIdx);
                    Console.WriteLine(
                        $@"Iter {iterIdx}, progress {progress(iterIdx) * 100:0.00}%, {secPassed:0.00} secs elapsed, {(1 - progressVal) * secPassed / progressVal:0.00} secs remain");
                }
                iterIdx += 1;
            }
            Console.WriteLine($@"Processing finished {DateTime.Now}");

        }

        /// <summary>
        /// Gets an string argument from console input.
        /// </summary>
        /// <param name="message">The message to display on the console before reading the input.</param>
        /// <param name="defaultArg">Uses this default argument if the console input is empty.</param>
        /// <returns>The string argumetn read from the console input.</returns>
        public static string GetArg(string message, string defaultArg)
        {
            if (message.IsNotEmptyOrBlank())
                Console.WriteLine($@"{message}, the default is '{defaultArg}':");
            var readArg = Console.ReadLine();
            return readArg.IsEmptyOrBlank() ? defaultArg : readArg;
        }

        public static T GetArg<T>(string message, Func<string, T> conversion, T defaultArg)
        {
            Console.WriteLine($@"{message}, the default is '{defaultArg}':");
            var readArg = Console.ReadLine();
            return readArg.IsEmptyOrBlank() ? defaultArg : conversion(readArg);
        }

        public static string GetArg(this string[] args, int argIdx, string defaultArg, params string[] messages)
        {
            string arg;
            if (args == null || args.Length <= argIdx)
            {
                if (messages.IsNotNullOrEmpty())
                {
                    foreach (var message in messages)
                        Console.WriteLine(message[0] == '@'
                            ? $@"{message.Substring(1)}, the default is '{defaultArg}':"
                            : message);
                }
                arg = Console.ReadLine();
            }
            else arg = args[argIdx];

            return arg.IsNullOrEmptyOrBlank() ? defaultArg : arg;
        }

        /// <summary>
        /// Gets the argument of type <typeparamref name="T"/> from one of the console application string arguments, or from console input if the argument is missing.
        /// </summary>
        /// <typeparam name="T">The output type of the argument.</typeparam>
        /// <param name="args">The console application arguments.</param>
        /// <param name="argIdx">The index of the argument in the <paramref name="args"/> array. If this index exceeds the size of the <paramref name="args"/> array,
        /// then it displays the <paramref name="messages"/> line by line in the console window and attempts to read an argument from the console.</param>
        /// <param name="conversion">The conversion method that converts the string argument to an argument of type <typeparamref name="T"/>.</param>
        /// <param name="defaultArg">The default argument if the string argument is <c>null</c> or empty or just consists of white spaces.</param>
        /// <param name="messages">The messages to be displayed line by line on the console window. Note if a message starts with symbol '@', then it is specially treated and a short text "the default is ..." is appended to the end of the message to display the default argument value.</param>
        /// <returns>An argument of <typeparamref name="T"/>.</returns>
        public static T GetArg<T>(this string[] args, int argIdx, Func<string, T> conversion, T defaultArg, params string[] messages)
        {
            string arg;
            if (args == null || args.Length <= argIdx)
            {
                if (messages.IsNotNullOrEmpty())
                {
                    foreach (var message in messages)
                    {
                        Console.WriteLine(message[0] == '@'
                            ? $@"{message.Substring(1)}, the default is {defaultArg}:"
                            : message);
                    }
                }
                arg = Console.ReadLine();
            }
            else arg = args[argIdx];

            return arg.IsNullOrEmptyOrBlank() ? defaultArg : conversion(arg);
        }

        public static OptionSet GetArgParse(this string[] args, OptionParser parser, string prefix = "--", string surfix = "=")
        {
            return parser.Parse(args, prefix.Singleton(), surfix.Singleton());
        }
    }

    public class OptionInfo
    {

        public OptionInfo(string key, object defaultArg = null, Func<string, object> converter = null, string description = null, bool isCategoryKey = false, string category = null,
            Func<IDictionary<string, dynamic>, bool> activation = null, bool required = true)
        {
            if (key.IsNullOrEmptyOrBlank()) throw new ArgumentException(); // the key cannot be an empty or blank string
            Key = key;
            DefaultValue = defaultArg;
            Converter = converter;
            if (description.IsNotNullOrEmptyOrBlank()) Description = description;
            Activation = activation;
            Required = required;
            DefaultArgType = DefaultValue?.GetType();
            if (isCategoryKey && category.IsNotNullOrEmpty()) throw new ArgumentException(); // a category key argument cannot belong to a category
            IsCategoryKey = isCategoryKey;

            category = category?.Trim();
            if (category.IsNotNullOrEmptyOrBlank())
            {
                if (category[0] == '!')
                {
                    CategoryNegation = true;
                    category = category.Substring(1).TrimStart();
                }
                Category = category;
            }

        }

        public OptionInfo((string, object, Func<string, object>, string, bool, string, Func<IDictionary<string, dynamic>, bool>, bool) tuple)
        : this(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8) { }

        public string Key { get; }

        public object DefaultValue { get; }

        public Type DefaultArgType { get; }

        public string Description { get; }

        public Func<string, object> Converter { get; }

        public Func<IDictionary<string, dynamic>, bool> Activation { get; }

        public bool Required { get; }


        public bool IsCategoryKey { get; }

        public string Category { get; }

        public bool CategoryNegation { get; }
    }

    public class OptionParser
    {
        HybridDictionary<string, OptionInfo> _argKeyInfoDict;
        OptionInfo[] _argKeyInfoList;
        private string _categoryKey;

        public OptionParser(params (string, object, Func<string, object>, string, bool, string, Func<IDictionary<string, dynamic>, bool>, bool)[] optionInfos)
        {
            var infoCount = optionInfos.Length;
            _argKeyInfoDict = new HybridDictionary<string, OptionInfo>();
            _argKeyInfoList = new OptionInfo[infoCount];
            for (var i = 0; i < infoCount; ++i)
            {
                var item = new OptionInfo(optionInfos[i]);
                if (item.IsCategoryKey)
                {
                    if (item.Activation != null || item.DefaultArgType != null && item.DefaultArgType != typeof(string))
                        throw new ArgumentException(); // category argument must be string
                    if (_categoryKey == null) _categoryKey = item.Key;
                    else throw new ArgumentException(); // multiple category key
                }
                _argKeyInfoDict.Add(item.Key, item);
                _argKeyInfoList[i] = item;
            }
        }

        public OptionParser(params OptionInfo[] optionInfos)
        {
            var infoCount = optionInfos.Length;
            _argKeyInfoDict = new HybridDictionary<string, OptionInfo>();
            _argKeyInfoList = new OptionInfo[infoCount];
            for (var i = 0; i < infoCount; ++i)
            {
                var item = optionInfos[i];
                if (item.IsCategoryKey)
                {
                    if (_categoryKey == null) _categoryKey = item.Key;
                    else throw new ArgumentException(); // multiple category key
                }
                _argKeyInfoDict.Add(item.Key, item);
                _argKeyInfoList[i] = item;
            }
        }

        string _removeArgStrQuotes(string argStr)
        {
            if (argStr.Length > 1)
            {
                switch (argStr[0])
                {
                    case '\'':
                        return argStr.RemoveQuotes('\'');
                    case '"':
                        return argStr.RemoveQuotes('"');
                }
            }

            return argStr;
        }

        dynamic _argConvert(Func<string, object> converter, string argStr, Type argType)
        {
            if (converter == null) // infers default conversion
            {
                if (argType != null)
                {
                    if (argType == typeof(int)) return argStr.ToInt32();
                    if (argType == typeof(long)) return argStr.ToInt64();
                    if (argType == typeof(double)) return argStr.ToDouble();
                    if (argType == typeof(float)) return argStr.ToSingle();
                    if (argType == typeof(bool)) return argStr.ToBoolean();
                    if (argType == typeof(DateTime)) return argStr.ToDateTime();
                }
                return argStr;
            }

            return converter(argStr);
        }

        bool _activation(OptionInfo info, HybridDictionary<string, dynamic> keyedArgs, string currCategory)
        {
            if (info.Category != null)
            {
                if (info.CategoryNegation == (info.Category == currCategory))
                    return false;
            }
            if (info.Activation != null)
            {
                // check if the current argument is activated
                try
                {
                    if (!info.Activation(keyedArgs))
                        return false;
                }
                catch { }
            }

            return true;
        }

        void _argProcess(string argKey, string argStr, HybridDictionary<string, dynamic> keyedArgs, ref string currCategory, OptionInfo info = null)
        {
            dynamic argVal;

            var enableConsole = false;
            if (info == null) _argKeyInfoDict.TryGetValue(argKey, out info);
            else enableConsole = true;

            if (info != null)
            {
                if (!_activation(info, keyedArgs, currCategory)) return;

                var defaultArgVal = info.DefaultValue;
                if (argStr.IsNullOrEmpty())
                {
                    if (enableConsole)
                    {
                        // if console input is enabled, tries to read the argument from input
                        Console.WriteLine($@"Input {info.Description ?? '\'' + info.Key + '\''}, the default is {defaultArgVal}:");
                        argStr = Console.ReadLine();
                        argVal = argStr.IsNullOrEmpty() ? defaultArgVal : _argConvert(info.Converter, argStr, info.DefaultArgType);
                    }
                    else
                        // the argument string is empty, uses the defaul if there is one
                        argVal = defaultArgVal;
                }
                else
                {
                    argStr = _removeArgStrQuotes(argStr);
                    argVal = _argConvert(info.Converter, argStr, info.DefaultArgType);
                }
            }
            else argVal = argStr.IsNullOrEmpty() ? null : _removeArgStrQuotes(argStr);

            keyedArgs.Add(argKey, argVal);
            if (argKey == _categoryKey)
            {
                if (argVal == null) throw new FormatException(); // a category argument cannot be empty
                currCategory = argVal;
            }
        }

        /// <summary>
        /// Parses options from the string arguments.
        /// </summary>
        /// <param name="args">The string arguments.</param>
        /// <param name="keyPrefix">The prefix for the arugment key. The default is "--", so an argument key-value pair specification can be written in format <c>--key value</c> (two argument slots). The argument value can be later retrieved by <see cref="OptionSet.GetArg{T}(string)"/>method. Flags without arugment values can be set using <c>--flag --key value</c> (the first argument is a flag named "flag", and the second argument is a key-value pair), where the existence of the flag can be determined later by <see cref="OptionSet.HasKey(string)"/> method.</param>
        /// <param name="keySurfix">The surfix for the argument key. The default is ":", so an argument key-value pair specification can be written in format "key=value" (one argument slot). A flag can be set using <c>falg=""</c>.</param>
        /// <param name="enableConsole"><c>true</c> if unspecified required argument </param>
        /// <returns>An <see cref="OptionSet"/> storing the parsed arguments.</returns>
        /// <remarks>Three styles of argument specification are supported. Different styles can be mixed.
        /// <list type="bullet">
        ///     <item>
        ///         <term><c>--key value</c></term>
        ///         <description>Occupies two argument slots. The '--' key prefix can be replaced by a customized prefix specified by <paramref name="keyPrefix"/>. The value can be retrieved by <see cref="OptionSet.GetArg{T}(string)"/>method from the returned <see cref="OptionSet"/> object. To specify a flag, simply skip the value. For example, <c>cmd --flag1 --flag2 --arg value</c> specifies two flags 'flag1' and 'flag2' and one argument with key 'arg'.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>key=value</c></term>
        ///         <description>Occupies one argument slot. The '=' key surfix can be replaced by a customized prefix specified by <paramref name="keySurfix"/>. The value can be retrieved by <see cref="OptionSet.GetArg{T}(string)"/>method from the returned <see cref="OptionSet"/> object. To specify a flag, make the value empty. For example, <c>cmd flag1= flag2= --arg value</c> specifies two flags 'flag1' and 'flag2' and one argument with key 'arg'. This is also an exmaple that two styles of argument specification can be mixed.</description>
        ///     </item>
        ///     <item>
        ///         <term>unkeyed argument</term>
        ///         <description>Unkeyed arguments are matched with unspecified required arguments in order. For example, suppose we define two required arguments "arg1", "arg2" and "arg3", then <c>cmd --arg2 value2 value1</c> has one keyed argument "arg2" with its value being "value2"; and "value1" is an unkeyed argument that will be assigned to "arg1", because "arg1" is the first unspecified argument.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public OptionSet Parse(string[] args, string keyPrefix = "--", string keySurfix = "=", bool enableConsole = false)
        {
            return Parse(args, keyPrefix.Singleton(), keySurfix.Singleton(), enableConsole);
        }


        public OptionSet Parse(string[] args, string[] prefixes, string[] surfixes, bool enableConsole = false)
        {
            var unkeyedArgStrs = new List<string>();
            var keyedArgs = new HybridDictionary<string, dynamic>();
            var argLen = args.Length;
            string currCategory = null;
            string prevKey = null; // for prefix keyed argument
            for (var idx = 0; idx < argLen; ++idx)
            {
                var rawArgStr = args[idx];

                var prefix = rawArgStr.StartsWithAny(prefixes);
                if (prefix != null)
                {
                    // parses arguments of format like "--name value"

                    var tmpKey = rawArgStr.Substring(prefix.Length);
                    if (tmpKey == "console") // buildin commands
                    {
                        enableConsole = true;
                        continue;
                    }

                    if (prevKey != null)
                    {
                        if (prevKey == _categoryKey) throw new FormatException(); // a category argument cannot be empty
                        keyedArgs.Add(prevKey, null);
                    }
                    prevKey = tmpKey;
                }
                else
                {
                    var suffixSearchResult = rawArgStr.IndexOfAnyWithQuotes(surfixes, startIndex: 0, leftQuotes: new[] { '"', '\'' }, rightQuotes: new[] { '"', '\'' });
                    if (suffixSearchResult != null)
                    {
                        // parses arguments of format like "name="value""
                        if (prevKey != null)
                        {
                            if (prevKey == _categoryKey) throw new FormatException(); // a category argument cannot be empty
                            keyedArgs.Add(prevKey, null);
                            prevKey = null;
                        }

                        var argKey = rawArgStr.Substring(0, suffixSearchResult.Position);
                        var argStr = rawArgStr.Substring(suffixSearchResult.Position + surfixes[suffixSearchResult.HitIndex].Length);

                        _argProcess(argKey, argStr, keyedArgs, ref currCategory);
                    }
                    else if (prevKey != null)
                    {
                        _argProcess(prevKey, rawArgStr, keyedArgs, ref currCategory);
                        prevKey = null;
                    }
                    else if (_categoryKey != null && currCategory == null) // first unkeyed argument is always the category key
                        _argProcess(_categoryKey, rawArgStr, keyedArgs, ref currCategory);
                    else unkeyedArgStrs.Add(rawArgStr);

                }
            }

            if (prevKey != null) keyedArgs.Add(prevKey, null);

            var unkeyedArgStrIdx = 0;
            foreach (var info in _argKeyInfoList)
            {
                if (!info.Required || keyedArgs.ContainsKey(info.Key)) continue;

                if (unkeyedArgStrIdx < unkeyedArgStrs.Count)
                    _argProcess(info.Key, unkeyedArgStrs[unkeyedArgStrIdx++], keyedArgs, ref currCategory, info);
                else if (enableConsole)
                    _argProcess(info.Key, null, keyedArgs, ref currCategory, info);
                else if (_activation(info, keyedArgs, currCategory))
                    keyedArgs.Add(info.Key, info.DefaultValue);
            }

            return new OptionSet(keyedArgs);
        }
    }

    public class OptionSet
    {
        HybridDictionary<string, dynamic> _keyedArgs;

        internal OptionSet(HybridDictionary<string, dynamic> keyedArgs)
        {
            _keyedArgs = keyedArgs;
        }
        public dynamic this[string key] => _keyedArgs.TryGetValue(key, out var arg) ? arg : null;

        public T GetArg<T>(string key)
        {
            var arg = this[key];
            return arg == null ? default : (T)arg;
        }

        public bool HasKey(string key)
        {
            return _keyedArgs.ContainsKey(key);
        }
    }
}
