using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    /// <summary>
    /// A 32-bit identifier generator using a file.
    /// </summary>
    public class FileBasedInt32IdGenerator : IIntIdentifierGenerator
    {
        string _path;
        int _initial;
        int _increment;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBasedInt32IdGenerator"/> class.
        /// </summary>
        /// <param name="path">The path of the file this generator uses.</param>
        /// <param name="initial">The initial identifier.</param>
        /// <param name="increment">The next identifier (except the first identifier, which is specified by <paramref name="initial"/>) is the previous identifier incremented by this value.</param>
        public FileBasedInt32IdGenerator(string path, int initial = 1, int increment = 1)
        {
            _path = path;
            _initial = initial;
            _increment = increment;
        }

        public void Reset()
        {
            var maxAttempt = 10;
            var currAttempt = 1;
            while (true)
            {
                try
                {
                    using (var fs = File.Open(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        var id = _initial;
                        fs.SeekToBegin();
                        fs.WriteInt64(id);
                    }
                    break;
                }
                catch
                {
                    if (currAttempt < maxAttempt)
                    {
                        ++currAttempt;
                        Threading.Thread.Sleep(100);
                    }
                    else break;
                }
            }
        }

        /// <summary>
        /// Gets the next 32-bit integer identifier.
        /// </summary>
        /// <returns>
        /// A 32-bit integer as an unique identifier if it is successfully generated; otherwise, <c>null</c>.
        /// </returns>
        public int? Next()
        {
            var maxAttempt = 10;
            var currAttempt = 1;

            if (!File.Exists(_path))
            {
                using (var fs = File.Create(_path))
                    fs.WriteInt32(_initial);
                return _initial;
            }
            else
            {
                while (true)
                {
                    try
                    {
                        using (var fs = File.Open(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            var id = fs.ReadInt32() + _increment;
                            fs.SeekToBegin();
                            fs.WriteInt32(id);
                            return id;
                        }
                    }
                    catch
                    {
                        if (currAttempt < maxAttempt)
                        {
                            ++currAttempt;
                            Threading.Thread.Sleep(100);
                        }
                        else return null;
                    }
                }
            }
        }
    }

    /// <summary>
    /// A 64-bit identifier generator using a file.
    /// </summary>
    public class FileBasedInt64IdGenerator : IInt64IdentifierGenerator
    {
        string _path;
        long _initial;
        int _increment;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBasedInt64IdGenerator"/> class.
        /// </summary>
        /// <param name="path">The path of the file this generator is based on.</param>
        /// <param name="initial">The initial identifier.</param>
        /// <param name="increment">The next identifier (except the first identifier, which is specified by <paramref name="initial"/>) is the previous identifier incremented by this value.</param>
        public FileBasedInt64IdGenerator(string path, long initial = 1, int increment = 1)
        {
            _path = path;
            _initial = initial;
            _increment = increment;
        }

        public void Reset()
        {
            var maxAttempt = 10;
            var currAttempt = 1;
            while (true)
            {
                try
                {
                    using (var fs = File.Open(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        var id = _initial;
                        fs.SeekToBegin();
                        fs.WriteInt64(id);
                    }
                    break;
                }
                catch
                {
                    if (currAttempt < maxAttempt)
                    {
                        ++currAttempt;
                        Threading.Thread.Sleep(100);
                    }
                    else break;
                }
            }
        }

        /// <summary>
        /// Gets the next 64-bit integer identifier.
        /// </summary>
        /// <returns>
        /// A 64-bit integer as an unique identifier if it is successfully generated; otherwise, <c>null</c>.
        /// </returns>
        public long? Next()
        {
            var maxAttempt = 10;
            var currAttempt = 1;

            if (!File.Exists(_path))
            {
                using (var fs = File.Create(_path))
                    fs.WriteInt64(_initial);
                return _initial;
            }
            else
            {
                while (true)
                {
                    try
                    {
                        using (var fs = File.Open(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            var id = fs.ReadInt64() + _increment;
                            fs.SeekToBegin();
                            fs.WriteInt64(id);
                            return id;
                        }
                    }
                    catch
                    {
                        if (currAttempt < maxAttempt)
                        {
                            ++currAttempt;
                            Threading.Thread.Sleep(100);
                        }
                        else return null;
                    }
                }
            }
        }
    }
}
