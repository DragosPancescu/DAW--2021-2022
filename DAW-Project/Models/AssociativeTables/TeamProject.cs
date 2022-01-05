using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models.AssociativeTables
{
    public class TeamProject : BaseEntity.BaseEntity
    {
        public Guid TeamId { get; set; }
        public Guid ProjectId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Project Project { get; set; }
    }
}
