using DAW_Project.Models.AssociativeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class Project : BaseEntity.BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<TeamProject> TeamProjects { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectVersion> ProjectVersions { get; set; }
    }
}
