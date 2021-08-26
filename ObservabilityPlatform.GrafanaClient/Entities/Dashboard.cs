using System.Text.Json.Serialization;
using ObservabilityPlatform.GrafanaClient.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class Dashboard
    {
        [JsonConverter(typeof(JsonZeroToNullConverter))]
        [JsonPropertyName("id")] public int Id { get; set; } = -1;
        
        [JsonPropertyName("uid")] public string Uid { get; set; }
        
        [JsonPropertyName("title")] public string Title { get; set; }
        
        [JsonPropertyName("tags")] public string[] Tags { get; set; } = {"templated"};
        
        [JsonPropertyName("timezone")] public string Timezone { get; set; } = "browser";
        
        [JsonPropertyName("schemaVersion")] public uint SchemaVersion { get; set; } = 16;
        
        [JsonPropertyName("version")] public uint Version { get; set; } = 0;
        
        [JsonPropertyName("refresh")] public string Refresh { get; set; } = "25s";
    }
}