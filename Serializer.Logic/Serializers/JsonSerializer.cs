using System;
using Newtonsoft.Json;

namespace TI.Serializer.Logic.Serializers
{

    /// <summary>
    /// JSON Serializer (Wrapper around Newtonsoft)
    /// </summary>
    public class JsonSerializer : Serializer
    {
        #region Overrides of Serializer

        public override string Serialize(object obj)
        {
            return Serialize(obj, Formatting.Indented);
        }
        public string Serialize(object obj, Formatting format = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(obj, format);
        }
        public override T Deserialize<T>(string json)
        {
            if (typeof(T).IsInterface || typeof(T).IsAbstract)
            {
                throw new ArgumentException("You cannot use an interface nor an abstract class as a type", nameof(T));
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public override object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        #endregion
    }
}