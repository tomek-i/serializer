using System;
using System.IO;

namespace TI.Serializer.Logic.Serializers
{
    public class XmlSerializer : Serializer
    {
        #region Overrides of Serializer

        public override string Serialize(object obj)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            StringWriter writer = new StringWriter();
            s.Serialize(writer, obj);
            return writer.ToString();
        }

        public override T Deserialize<T>(string xml)
        {
            return Deserialize(xml, typeof(T)) as T;
        }

        public override object Deserialize(string xml, Type type)
        {
            if(type==null) throw new NullReferenceException($"The {nameof(type)} cannot be null.");

            return new System.Xml.Serialization.XmlSerializer(type).Deserialize(new StringReader(xml));
        }

        public override object Deserialize(string serializedString)
        {
            throw new NotImplementedException("You have to use Deserialize(xm,type)");
        }

        #endregion
    }
}