using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Requests
{
    public class PostDatasourceRequest
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }
        
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }
        
        [JsonProperty(PropertyName = "access")] public string Access { get; set; } = "proxy";

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }
        
        [JsonProperty(PropertyName = "basicAuth")] public bool BasicAuth { get; set; }
    }
}