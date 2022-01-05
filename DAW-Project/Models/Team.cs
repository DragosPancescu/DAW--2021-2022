using DAW_Project.Models.AssociativeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class Team : BaseEntity.BaseEntity
    {
        public string TeamName { get; set; }

        public string Department { get; set; }

        public Guid LeadId { get; set; }

        public virtual ICollection<UserTeam> UserTeams { get; set; }
        public virtual ICollection<TeamProject> TeamProjects { get; set; }
    }
}
