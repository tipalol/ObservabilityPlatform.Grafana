using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class GetPrometheusSourceResponse : GetDatasourceResponse
    {
        [JsonProperty(PropertyName = "jsonData")] public JsonData Data { get; set; }
        
        public class JsonData
        {
            [JsonProperty(PropertyName = "httpMethod")] public string HttpMethod { get; set; }
        }
    }
}