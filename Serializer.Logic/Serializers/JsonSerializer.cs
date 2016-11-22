using System;
using Newtonsoft.Json;

namespace TI.Serializer.Logic.Serializers
{
    
    public class JsonSerializer : Serializer
    {
        #region Overrides of Serializer

        public override string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public override T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public override object Deserialize(string json, Type type=null)
        {
            return type==null ? JsonConvert.DeserializeObject(json) : JsonConvert.DeserializeObject(json, type);
        }

        #endregion
    }
}