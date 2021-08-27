using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Entities;

namespace ObservabilityPlatform.GrafanaClient.Requests
{
    public class DashboardCreationRequest
    {
        [JsonProperty(PropertyName = "dashboard")] public Dashboard Dashboard { get; set; }

        [JsonProperty(PropertyName = "folderId")] public uint FolderId { get; set; } = 0;

        [JsonProperty(PropertyName = "folderUid")] public string FolderUid { get; set; } = "DMFpWkVnz";

        [JsonProperty(PropertyName = "message")] public string Message { get; set; } = "Make changes in dashboard";

        [JsonProperty(PropertyName = "overwrite")] public bool Overwrite { get; set; } = false;
    }
}