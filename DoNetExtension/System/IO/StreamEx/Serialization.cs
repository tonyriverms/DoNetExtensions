using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static partial class StreamEx
    {
        /// <summary>
        /// Saves a serializable object to the specified path.
        /// </summary>
        /// <param name="obj">The object to be serialized.</param>
        /// <param name="path">The file to write to. </param>
        public static void Serialize(object obj, string path)
        {
            using (Stream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Loads a serialized object from the specified path.
        /// </summary>
        /// <param name="path">The file to read from.</param>
        /// <returns>The deserialized object.</returns>
        public static object Deserialize(string path)
        {
            if (File.Exists(path))
            {
                object obj;
                using (Stream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    obj = bf.Deserialize(fs);
                }
                return obj;
            }
            else return null;
        }

        /// <summary>
        /// Loads a serialized object from the specified path. 
        /// If the file does not exist or the deserializing process fails, a default object will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the serialized object.</typeparam>
        /// <param name="path">The file to read from.</param>
        /// <returns>The deserialized object or the default object.</returns>
        public static T DeserializeOrCreateO<T>(string path)
        {
            object obj = Deserialize(path);
            if (obj == null) return default(T);
            else return (T)obj;
        }
    }
}
