using System.Text.Json.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class SecureJsonData
    {
        [JsonPropertyName("basicAuthPassword")]
        public string BasicAuthPassword { get; set; }
    }
}