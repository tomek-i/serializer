using System;
using TISerializer.Logic.API;

namespace TISerializer.Logic
{
    public abstract class Serializer : ISerializer
    {
        public abstract string Serialize(object anyObject);
        public abstract T Deserialize<T>(string serializedString) where T:class;
        public abstract object Deserialize(string serializedString, Type type= null);
    }
}
