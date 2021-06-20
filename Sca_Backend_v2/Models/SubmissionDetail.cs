using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Models
{
    public class SubmissionDetail
    {
        public int SubmissionDetailId { get; set; }
        public string Title { get; set; }
        public string RequestorAlias { get; set; }
        public string ManagerAlias { get; set; }
        public string TeamAlias { get; set; }
        public string AdditionalContacts { get; set; }
        public string BusinessGroup { get; set; }
        public string SubmissionName { get; set; }
        public string VersionNumber { get; set; }
        public string ProductFamily { get; set; }
        public string ReleaseType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ProductOS { get; set; }
        public string ProductLanguages { get; set; }
        public string FileCollectionsIncluded { get; set; }
        public int StageServerId { get; set; }
        public string StageServerPath { get; set; }
        public string RetrievalOwnerAlias { get; set; }
        public long FileSizeInBytes { get; set; }
        public string Notes { get; set; }
        public int FileCount { get; set; }
        public int LineItemId { get; set; }
        public int SubmissionId { get; set; }
        public long IcmTicketId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string RevisedSubmissionName { get; set; }
    }
}
