using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MyChatDB.src.util
{
    internal class NormalizeJson
    {

        public static object Normalize(object value)
        {
            if (value == null)
                return null;
            if (value is JObject jObject)
                return NormalizeJObject(jObject);
            else if (value is JArray jArray)
                return NormalizeJArray(jArray);
            else
                return value;
        }

        public static List<object> NormalizeJArray(JArray jArray)
        {
            var list = new List<object>();
            foreach (var item in jArray)
                list.Add(Normalize(item));
            return list;
        }

        public static Dictionary<string, object> NormalizeJObject(JObject jObject)
        {
            var dict = new Dictionary<string, object>();
            foreach (var property in jObject.Properties())
                dict[property.Name] = Normalize(property.Value);
            return dict;
        }

    }
}
