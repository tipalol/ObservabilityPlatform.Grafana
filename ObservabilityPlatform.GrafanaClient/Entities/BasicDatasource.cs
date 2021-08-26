using System.Text.Json.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class BasicDatasource : Datasource
    {
        [JsonPropertyName("basicAuthUser")] public string BasicAuthUser { get; set; }
        
        [JsonPropertyName("secureJsonData")] public SecureJsonData SecureJsonData { get; set; }
    }
}