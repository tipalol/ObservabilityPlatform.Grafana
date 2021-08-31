using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class GetElasticSourceResponse : GetDatasourceResponse
    {
        [JsonProperty(PropertyName = "jsonData")] public JsonData Data { get; set; }
        
        public class JsonData
        {
            [JsonProperty(PropertyName = "esVersion")] public string EsVersion { get; set; }
            
            [JsonProperty(PropertyName = "includeFrozen")] public bool IncludeFrozen { get; set; }
            
            [JsonProperty(PropertyName = "logLevelField")] public string LogLevelField { get; set; }
            
            [JsonProperty(PropertyName = "logMessageField")] public string LogMessageField { get; set; }
            
            [JsonProperty(PropertyName = "maxConcurrentShardRequests")] public int MaxConcurrentShardRequests { get; set; }
            
            [JsonProperty(PropertyName = "timeField")] public string TimeField { get; set; }
        }
    }
}