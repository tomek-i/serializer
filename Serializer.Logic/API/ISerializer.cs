using System;

namespace TI.Serializer.Logic.API
{
    /// <summary>
    /// Serializer Interface
    /// </summary>
    public interface ISerializer
    {
        string Serialize(object anyObject);
        T Deserialize<T>(string serializedString) where T : class;
        object Deserialize(string serializedString, Type type);
        object Deserialize(string serializedString);
    }
}