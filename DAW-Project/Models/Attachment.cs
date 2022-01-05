using DAW_Project.Models.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class Attachment : BaseEntity.BaseEntity
    {
        public Guid ReportId { get; set; }
        public Guid AuthorId { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public virtual BugReport BugReport { get; set; }
    }
}
