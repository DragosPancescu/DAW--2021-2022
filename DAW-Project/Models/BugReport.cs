using DAW_Project.Models.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class BugReport : BaseEntity.BaseEntity
    {
        public Guid VersionId { get; set; }
        public Guid AuthorId { get; set; }
        public BugType BugType { get; set; }
        public string BugDescription { get; set; }
        public DateTime DiscoveryDate { get; set; }
        public BugSeverity Severity { get; set; }
        public bool Resolved { get; set; }
        public virtual ProjectVersion ProjectVersion { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual PossibleCause PossibleCause { get; set; }
    }
}
