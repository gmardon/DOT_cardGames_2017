using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.IO
{
    public class RawObjectReader
    {
        public static T Load<T>(String a_content)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(a_content)));
        }
    }
}