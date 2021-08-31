using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Entities;

namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class PostDatasourceResponse
    {
        [JsonProperty(PropertyName = "datasource")] public Datasource Datasource { get; set; }
        
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }
        
        [JsonProperty(PropertyName = "message")] public string Message { get; set; }
        
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }
    }
}