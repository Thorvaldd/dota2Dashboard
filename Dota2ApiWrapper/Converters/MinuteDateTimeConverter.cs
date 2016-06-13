using System;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Converters
{
    public class MinuteDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ts = TimeSpan.FromMinutes(double.Parse(reader.Value.ToString()));
            var dt = new DateTime(ts.Ticks).ToString("HH:mm");
            return dt;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (string);
        }
    }
}
