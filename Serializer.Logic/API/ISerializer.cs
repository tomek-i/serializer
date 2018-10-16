using System;

namespace TI.Serializer.Logic.API
{
    public interface ISerializer
    {
        string Serialize(object anyObject);
        T Deserialize<T>(string serializedString) where T : class;
        object Deserialize(string serializedString, Type type);
        object Deserialize(string serializedString);
    }
}