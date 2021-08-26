using System.Text.Json.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class Datasource
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        
        [JsonPropertyName("type")] public string Type { get; set; }
        
        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("access")] public string Access { get; set; } = "proxy";

        [JsonPropertyName("basicAuth")] public bool BasicAuth { get; set; }
    }
}