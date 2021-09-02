namespace ObservabilityPlatform.GrafanaClient.Responses
{
    public class PostDatasourceResponse
    {
        public string Result { get; set; }
        public int Id { get; set; }
        public string Exception { get; set; }
        public int Status { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedSuccessfully { get; set; }
        public int CreationOptions { get; set; }
        public string AsyncState { get; set; }
        public bool IsFaulted { get; set; }
    }
}