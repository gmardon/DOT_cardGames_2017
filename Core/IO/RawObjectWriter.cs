﻿using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Poker.Core.IO
{
    public class RawObjectWriter
    {
        /// <summary>
        /// Store object in memory stream in JSON format
        /// </summary>
        /// <param name="a_object">Object to save</param>
        /// <returns>MemoryStream fill by object data</returns>
        public static String Save(object a_object)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(a_object.GetType());
            serializer.WriteObject(stream, a_object);
            stream.Position = 0;
            return new StreamReader(stream).ReadToEnd();
        }
    }
}