using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models.DTOs
{
    public class VersionRequestDTO
    {
        public Guid ProjectId { get; set; }
        public DateTime LaunchDate { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int PatchVersion { get; set; }
    }
}
