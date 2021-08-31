using System.Collections.Generic;
using Newtonsoft.Json;

namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class Datasource
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }
        
        [JsonProperty(PropertyName = "uid")] public string Uid { get; set; }
        
        [JsonProperty(PropertyName = "orgId")] public int OrganizationId { get; set; }
        
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }
        
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }
        
        [JsonProperty(PropertyName = "typeLogoId")] public string TypeLogoUrl { get; set; }
        
        [JsonProperty(PropertyName = "access")] public string Access { get; set; } = "proxy";

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }
        
        [JsonProperty(PropertyName = "password")] public string Password { get; set; }
        
        [JsonProperty(PropertyName = "user")] public string User { get; set; }
        
        [JsonProperty(PropertyName = "database")] public string Database { get; set; }

        [JsonProperty(PropertyName = "basicAuth")] public bool BasicAuth { get; set; }
        
        [JsonProperty(PropertyName = "basicAuthUser")] public string BasicAuthUser { get; set; }
        
        [JsonProperty(PropertyName = "basicAuthPassword")] public string BasicAuthPassword { get; set; }
        
        [JsonProperty(PropertyName = "withCredentials")] public bool WithCredentials { get; set; }
        
        [JsonProperty(PropertyName = "isDefault")] public bool IsDefault { get; set; }
        
        [JsonProperty(PropertyName = "jsonData")] public Dictionary<string, string> JsonData { get; set; }

        [JsonProperty(PropertyName = "secureJsonFields")] public Dictionary<string, string> SecureJsonFields { get; set; }
        
        [JsonProperty(PropertyName = "version")] public int Version { get; set; }
        
        [JsonProperty(PropertyName = "readOnly")] public bool ReadOnly { get; set; }
    }
}