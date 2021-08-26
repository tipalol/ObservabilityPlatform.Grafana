using System.Text.Json.Serialization;
using ObservabilityPlatform.GrafanaClient.Entities;

namespace ObservabilityPlatform.GrafanaClient.Requests
{
    public class DashboardCreationRequest
    {
        [JsonPropertyName("dashboard")] public Dashboard Dashboard { get; set; }

        [JsonPropertyName("folderId")] public uint FolderId { get; set; } = 0;
        
        [JsonPropertyName("folderUid")] public string FolderUid { get; set; }

        [JsonPropertyName("message")] public string Message { get; set; } = "Make changes in dashboard";

        [JsonPropertyName("overwrite")] public bool Overwrite { get; set; } = false;
    }
}