using System;

namespace TI.Serializer.Logic.Serializers
{
    public class SoapSerializer : Serializer
    {
        public override T Deserialize<T>(string serializedString)
        {
            throw new NotImplementedException();
        }

        public override object Deserialize(string serializedString, Type type = null)
        {
            throw new NotImplementedException();
        }

        public override string Serialize(object anyObject)
        {
            throw new NotImplementedException();
        }
    }
}
