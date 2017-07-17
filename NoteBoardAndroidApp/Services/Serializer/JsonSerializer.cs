using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace NoteBoardAndroidApp.Services.Serializer
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string json)
        {
            var obj = Activator.CreateInstance<T>();
            using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(memoryStream);
                return obj;
            }
        }

        public string Serialize<T>(T entity)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, entity);

            return stream1.ToString();
        }
    }
}