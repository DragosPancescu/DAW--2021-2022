using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class ProjectVersion : BaseEntity.BaseEntity
    {
        public Guid ProjectId { get; set; }
        public DateTime LaunchDate { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int PatchVersion { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<BugReport> BugReports { get; set; }
    }
}
