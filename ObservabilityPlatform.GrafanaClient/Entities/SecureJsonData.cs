using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class SecureJsonData
    {
        [JsonProperty(PropertyName = "basicAuthPassword")] public string BasicAuthPassword { get; set; }
    }
}