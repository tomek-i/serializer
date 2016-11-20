using System;

namespace TISerializer.Logic.API
{
    
    public interface ISerializer
    {
        string Serialize(object anyObject);
        T Deserialize<T>(string serializedString) where T : class;
        object Deserialize(string serializedString,Type type=null);
    }
}