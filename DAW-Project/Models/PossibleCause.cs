using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class PossibleCause : BaseEntity.BaseEntity
    {
        public Guid ReportId { get; set; }
        public Guid AuthorId { get; set; }
        public string CauseDescription { get; set; }
        public virtual BugReport BugReport { get; set; }
    }
}
