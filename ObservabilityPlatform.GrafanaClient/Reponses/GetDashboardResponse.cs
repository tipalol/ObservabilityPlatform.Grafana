using System;
using System.Collections.Generic;

namespace ObservabilityPlatform.GrafanaClient.Reponses
{
    public class GetDashboardResponse
    {
        public Meta meta { get; set; }
        public Dashboard dashboard { get; set; }
        
        public class Meta
        {
            public string type { get; set; }
            public bool canSave { get; set; }
            public bool canEdit { get; set; }
            public bool canAdmin { get; set; }
            public bool canStar { get; set; }
            public string slug { get; set; }
            public string url { get; set; }
            public DateTime expires { get; set; }
            public DateTime created { get; set; }
            public DateTime updated { get; set; }
            public string updatedBy { get; set; }
            public string createdBy { get; set; }
            public int version { get; set; }
            public bool hasAcl { get; set; }
            public bool isFolder { get; set; }
            public int folderId { get; set; }
            public string folderUid { get; set; }
            public string folderTitle { get; set; }
            public string folderUrl { get; set; }
            public bool provisioned { get; set; }
            public string provisionedExternalId { get; set; }
        }

        public class Target
        {
            public int limit { get; set; }
            public bool matchAny { get; set; }
            public List<string> tags { get; set; }
            public string type { get; set; }
        }

        public class List
        {
            public int builtIn { get; set; }
            public string datasource { get; set; }
            public bool enable { get; set; }
            public bool hide { get; set; }
            public string iconColor { get; set; }
            public string name { get; set; }
            public Target target { get; set; }
            public string type { get; set; }
        }

        public class Annotations
        {
            public List<List> list { get; set; }
        }

        public class Color
        {
            public string mode { get; set; }
        }

        public class HideFrom
        {
            public bool legend { get; set; }
            public bool tooltip { get; set; }
            public bool viz { get; set; }
        }

        public class ScaleDistribution
        {
            public string type { get; set; }
        }

        public class Stacking
        {
            public string group { get; set; }
            public string mode { get; set; }
        }

        public class ThresholdsStyle
        {
            public string mode { get; set; }
        }

        public class Custom
        {
            public string axisLabel { get; set; }
            public string axisPlacement { get; set; }
            public int barAlignment { get; set; }
            public string drawStyle { get; set; }
            public int fillOpacity { get; set; }
            public string gradientMode { get; set; }
            public HideFrom hideFrom { get; set; }
            public string lineInterpolation { get; set; }
            public int lineWidth { get; set; }
            public int pointSize { get; set; }
            public ScaleDistribution scaleDistribution { get; set; }
            public string showPoints { get; set; }
            public bool spanNulls { get; set; }
            public Stacking stacking { get; set; }
            public ThresholdsStyle thresholdsStyle { get; set; }
        }

        public class Step
        {
            public string color { get; set; }
            public int? value { get; set; }
        }

        public class Thresholds
        {
            public string mode { get; set; }
            public List<Step> steps { get; set; }
        }

        public class Defaults
        {
            public Color color { get; set; }
            public Custom custom { get; set; }
            public List<object> mappings { get; set; }
            public Thresholds thresholds { get; set; }
        }

        public class FieldConfig
        {
            public Defaults defaults { get; set; }
            public List<object> overrides { get; set; }
        }

        public class GridPos
        {
            public int h { get; set; }
            public int w { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Legend
        {
            public List<object> calcs { get; set; }
            public string displayMode { get; set; }
            public string placement { get; set; }
        }

        public class Tooltip
        {
            public string mode { get; set; }
        }

        public class Options
        {
            public Legend legend { get; set; }
            public Tooltip tooltip { get; set; }
        }

        public class Filter
        {
            public List<string> fields { get; set; }
        }

        public class Target2
        {
            public string queryType { get; set; }
            public string refId { get; set; }
            public string target { get; set; }
            public string channel { get; set; }
            public Filter filter { get; set; }
        }

        public class Panel
        {
            public string datasource { get; set; }
            public FieldConfig fieldConfig { get; set; }
            public GridPos gridPos { get; set; }
            public int id { get; set; }
            public Options options { get; set; }
            public List<Target> targets { get; set; }
            public string title { get; set; }
            public string type { get; set; }
        }

        public class Templating
        {
            public List<object> list { get; set; }
        }

        public class Time
        {
            public string from { get; set; }
            public string to { get; set; }
        }

        public class Timepicker
        {
        }

        public class Dashboard
        {
            public Annotations annotations { get; set; }
            public bool editable { get; set; }
            public object gnetId { get; set; }
            public int graphTooltip { get; set; }
            public int id { get; set; }
            public List<object> links { get; set; }
            public List<Panel> panels { get; set; }
            public int schemaVersion { get; set; }
            public string style { get; set; }
            public List<object> tags { get; set; }
            public Templating templating { get; set; }
            public Time time { get; set; }
            public Timepicker timepicker { get; set; }
            public string timezone { get; set; }
            public string title { get; set; }
            public string uid { get; set; }
            public int version { get; set; }
        }
        
    }
}