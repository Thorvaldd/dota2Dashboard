using System;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Converters
{
    public class ApplicationImageConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.ContractResolver.ResolveContract(objectType);
            
            var value = reader.Value.ToString();
            return $"http://media.steampowered.com/steamcommunity/public/images/apps/{obj.ToString()}/{value}.jpg";
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
