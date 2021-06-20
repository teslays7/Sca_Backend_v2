namespace Sca_Backend_v2.Models
{
    public class CopyToStageDetail
    {
        public int SubmissionId { get; set; }
        public int LineItemId { get; set; }
        public string DestinationPath { get; set; }
        public long FileSize { get; set; }
        public int FileCount { get; set; }
        public string SourcePath { get; set; }
    }
}
