using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Serialization;

namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class GetDashboardResponse
    {
        [JsonProperty(PropertyName = "meta")] public Meta MetaInfo { get; set; }
        [JsonProperty(PropertyName = "dashboard")] public Dashboard DashboardWow { get; set; }

        public class Dashboard
        {
            [JsonProperty(PropertyName = "annotations")] public Annotations AnnotationList { get; set; }
            [JsonProperty(PropertyName = "editable")] public bool Editable { get; set; }
            [JsonProperty(PropertyName = "gnetId")] public object GNetId { get; set; }
            [JsonProperty(PropertyName = "graphTooltip")] public int GraphTooltip { get; set; }
            [JsonProperty(PropertyName = "hideControls")] public bool HideControls { get; set; }
            [JsonConverter(typeof(JsonZeroToNullConverter))]
            [JsonProperty(PropertyName = "id")] public int Id { get; set; }
            [JsonProperty(PropertyName = "links")] public List<object> Links { get; set; }
            [JsonProperty(PropertyName = "panels")] public List<object> Panels { get; set; }
            [JsonProperty(PropertyName = "schemaVersion")] public uint SchemaVersion { get; set; }
            [JsonProperty(PropertyName = "style")] public string Style { get; set; }
            [JsonProperty(PropertyName = "tags")] public string[] Tags { get; set; }
            [JsonProperty(PropertyName = "templating")] public object Templating { get; set; }
            [JsonProperty(PropertyName = "time")] public object Time { get; set; }
            [JsonProperty(PropertyName = "timepicker")] public object Timepicker { get; set; }
            [JsonProperty(PropertyName = "timezone")] public string Timezone { get; set; }
            [JsonProperty(PropertyName = "uid")] public string Uid { get; set; }
            [JsonProperty(PropertyName = "title")] public string Title { get; set; }
            [JsonProperty(PropertyName = "version")] public uint Version { get; set; }
            [JsonProperty(PropertyName = "refresh")] public string Refresh { get; set; }

            public class Annotations
            {
                [JsonProperty(PropertyName = "list")] public List<Annotation> AnnotationsList { get; set; }
            }

            public class Annotation
            {
                [JsonProperty(PropertyName = "builtIn")] public int BuiltIn { get; set; }
                [JsonProperty(PropertyName = "datasource")] public string Datasource { get; set; }
                [JsonProperty(PropertyName = "enable")] public bool Enable { get; set; }
                [JsonProperty(PropertyName = "hide")] public bool Hide { get; set; }
                [JsonProperty(PropertyName = "iconColor")] public string IconColor { get; set; }
                [JsonProperty(PropertyName = "name")] public string Name { get; set; }
                [JsonProperty(PropertyName = "type")] public string Type { get; set; }
            }
        }
        
        public class Meta
        {
            [JsonProperty(PropertyName = "type")] public string Type { get; set; }
            [JsonProperty(PropertyName = "canSave")] public bool CanSave { get; set; }
            [JsonProperty(PropertyName = "canEdit")] public bool CanEdit { get; set; }
            [JsonProperty(PropertyName = "canAdmin")] public bool CanAdmin { get; set; }
            [JsonProperty(PropertyName = "canStar")] public bool CanStar { get; set; }
            [JsonProperty(PropertyName = "slug")] public string Slug { get; set; }
            [JsonProperty(PropertyName = "url")] public string Url { get; set; }
            [JsonProperty(PropertyName = "expires")] public DateTime Expires { get; set; }
            [JsonProperty(PropertyName = "created")] public DateTime Created { get; set; }
            [JsonProperty(PropertyName = "updated")] public DateTime Updated { get; set; }
            [JsonProperty(PropertyName = "updatedBy")] public string UpdatedBy { get; set; }
            [JsonProperty(PropertyName = "createdBy")] public string CreatedBy { get; set; }
            [JsonProperty(PropertyName = "version")] public int Version { get; set; }
            [JsonProperty(PropertyName = "hasAcl")] public bool HasAcl { get; set; }
            [JsonProperty(PropertyName = "isFolder")] public bool IsFolder { get; set; }
            [JsonProperty(PropertyName = "folderId")] public int FolderId { get; set; }
            [JsonProperty(PropertyName = "folderTitle")] public string FolderTitle { get; set; }
            [JsonProperty(PropertyName = "folderUrl")] public string FolderUrl { get; set; }
            [JsonProperty(PropertyName = "provisioned")] public bool Provisioned { get; set; }
            [JsonProperty(PropertyName = "provisionedExternalId")] public string ProvisionedExternalId { get; set; }
        }
    }
}