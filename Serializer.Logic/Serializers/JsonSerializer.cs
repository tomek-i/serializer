using System;
using Newtonsoft.Json;

namespace TI.Serializer.Logic.Serializers
{
    public enum Format
    {
        None,
        Indented
    }
    public class JsonSerializer : Serializer
    {
        #region Overrides of Serializer

        public override string Serialize(object obj)
        {
            return Serialize(obj, Format.Indented);
        }
        public  string Serialize(object obj, Format format)
        {
            Formatting form = Formatting.None;
            if(format == Format.Indented)
                form = Formatting.Indented;

            return JsonConvert.SerializeObject(obj, form);
        }
        public override T Deserialize<T>(string json)
        {
            if (typeof (T).IsInterface || typeof (T).IsAbstract)
            {
                throw new ArgumentException("You cannot use an interace nor an abstract class as a type",nameof(T));
                //var obj = Deserialize(json);
               // return obj as T;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public override object Deserialize(string json, Type type=null)
        {
            return type==null ? JsonConvert.DeserializeObject(json) : JsonConvert.DeserializeObject(json, type);
        }

        #endregion
    }
}