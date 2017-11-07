using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.IO
{
    public class RawObjectWriter
    {
        /// <summary>
        /// Store object in memory stream in JSON format
        /// </summary>
        /// <param name="a_object">Object to save</param>
        /// <returns>MemoryStream fill by object data</returns>
        public static MemoryStream Save(object a_object)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(a_object.GetType());
            serializer.WriteObject(stream, a_object);
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Store object in JSON format file
        /// </summary>
        /// <param name="a_object">Object to save</param>
        /// <param name="path">File path for object backup</param>
        public static void Save(object a_object, String path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                RawObjectWriter.Save(a_object).WriteTo(writer.BaseStream);
            }
        }
    }
}