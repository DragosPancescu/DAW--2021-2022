using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models.AssociativeTables
{
    public class UserTeam : BaseEntity.BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
