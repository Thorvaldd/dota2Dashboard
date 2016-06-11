using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Converters
{
    public class StringUriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();
            Uri uri;

            if (string.IsNullOrEmpty(value))
                return null;

            //if (!value.Contains("http://") || !value.Contains("https://"))
            //    value = "http://" + value;
            Regex rgx = new Regex(@"^(http(s)?)://.*$", RegexOptions.Compiled);
            if(!rgx.IsMatch(value))
                value = "http://" + value;

            Uri.TryCreate(value, UriKind.Absolute, out uri);

            return uri;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
