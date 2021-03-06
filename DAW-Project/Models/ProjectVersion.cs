using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public virtual Project Project { get; set; }
        [JsonIgnore]
        public virtual ICollection<BugReport> BugReports { get; set; }
    }
}
