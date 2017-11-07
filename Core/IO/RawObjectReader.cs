using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.IO
{
    public class RawObjectReader
    {
        /// <summary>
        /// Load object from stream (in JSON format) to object
        /// </summary>
        /// <param name="a_stream">Stream fill by object</param>
        /// <param name="a_object">Object to save</param>
        /// <returns>Object fill by properties</returns>
        public static T Load<T>(Stream a_stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(a_stream);
        }

        /// <summary>
        /// Read and load object in JSON format file
        /// </summary>
        /// <param name="a_object">Object to load</param>
        /// <param name="path">File path for object backup</param>
        public static T Load<T>(String path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return (T)RawObjectReader.Load<T>(reader.BaseStream);
            }
        }
    }
}