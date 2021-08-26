using System;
using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Serialization
{
    public class JsonZeroToNullConverter : JsonConverter
    {
        public JsonZeroToNullConverter() : base()
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var num = (int) value!;

            var result = num == -1 ? null : value;

            writer.WriteValue(result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return existingValue ?? -1;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}