using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LULU_WCF_Service.Common
{
    public static class Serializers<T>
    {
        public static object EntityUtilities { get; private set; }

        public static string Serialize(T obj)
        {
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));

                using (MemoryStream writer = new MemoryStream())
                {
                    using (StreamReader reader = new StreamReader(writer))
                    {
                        serializer.WriteObject(writer, obj);

                        writer.Seek(0, SeekOrigin.Begin);

                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static string SerializeList(List<T> objs)
        {
            try
            {
                var sb = new StringBuilder();

                foreach (T obj in objs)
                {
                    sb.Append(Serialize(obj));
                }

                return sb.ToString().Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public static T Deserialize(string objString)
        {
            T result = default(T);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(objString)))
                {
                    stream.Position = 0;

                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public static List<T> DeserializeList(string objects)
        {
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<T>));

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(objects)))
                {
                    stream.Position = 0;

                    return (List<T>)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return null;
        }
    }
}
