using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models.DTOs.TeamDTO
{
    public class TeamRequestDTO
    {
        public string TeamName { get; set; }

        public string Department { get; set; }

        public Guid LeadId { get; set; }
    }
}
