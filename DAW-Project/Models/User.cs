using DAW_Project.Models.AssociativeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAW_Project.Models
{
    public class User : BaseEntity.BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
}
