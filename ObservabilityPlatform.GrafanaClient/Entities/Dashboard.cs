using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class Dashboard
    {
        [JsonConverter(typeof(JsonZeroToNullConverter))]
        [JsonProperty(PropertyName = "id")] public int Id { get; set; } = -1;
        
        [JsonProperty(PropertyName = "uid")] public string Uid { get; set; }
        
        [JsonProperty(PropertyName = "title")] public string Title { get; set; }
        
        [JsonProperty(PropertyName = "tags")] public string[] Tags { get; set; } = {"templated"};
        
        [JsonProperty(PropertyName = "timezone")] public string Timezone { get; set; } = "browser";
        
        [JsonProperty(PropertyName = "schemaVersion")] public uint SchemaVersion { get; set; } = 16;
        
        [JsonProperty(PropertyName = "version")] public uint Version { get; set; } = 0;
        
        [JsonProperty(PropertyName = "refresh")] public string Refresh { get; set; } = "25s";
    }
}