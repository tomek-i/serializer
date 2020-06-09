using Newtonsoft.Json;
using System;

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
            return Serialize(obj, format, null);
        }
        public string Serialize(object obj, Formatting format, JsonSerializerSettings settings = null)
        {
            if (settings == null)
            {
                return JsonConvert.SerializeObject(obj, format);
            }
            else
            {
                return JsonConvert.SerializeObject(obj, format, settings);
            }
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