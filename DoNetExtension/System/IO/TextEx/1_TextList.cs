using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class TextEx
    {
        public static void WriteTextList(this TextWriter writer, string[] texts)
        {
            var count = texts.Length;
            writer.WriteLine(texts.Length);
            for (int i = 0; i < count; ++i)
                writer.WriteLine(texts[i]);
        }

        public static string[] ReadTextList(this TextReader reader)
        {
            var count = reader.ReadLine().ToInt32();
            var output = new string[count];
            for (int i = 0; i < count; ++i)
                output[i] = reader.ReadLine();
            return output;
        }
    }
}
