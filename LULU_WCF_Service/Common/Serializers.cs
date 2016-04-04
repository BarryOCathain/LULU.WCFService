using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LULU_WCF_Service.Common
{
    public static class Serializers<T>
    {
        public static string Serialize(T obj)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);

                serializer.Serialize(writer, obj);

                return sb.ToString();
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
                var serializer = new XmlSerializer(typeof(T));
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);

                foreach (T obj in objs)
                {
                    serializer.Serialize(writer, obj);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public static T Deserialize(string objString)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(new StringReader(objString));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to deserialize xml string to data contract object:", ex);
            }
        }

    }
}
