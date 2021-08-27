using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Entities
{
    public class BasicDatasource : Datasource
    {
        [JsonProperty(PropertyName = "basicAuthUser")] public string BasicAuthUser { get; set; }
        
        [JsonProperty(PropertyName = "secureJsonData")] public SecureJsonData SecureJsonData { get; set; }
    }
}