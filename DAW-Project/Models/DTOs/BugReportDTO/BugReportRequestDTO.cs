using DAW_Project.Models.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Models.DTOs.BugReportDTO
{
    public class BugReportRequestDTO
    {   
        public string ProjectName { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int PatchVersion { get; set; }
        public Guid AuthorId { get; set; }
        public BugType BugType { get; set; }
        public string BugDescription { get; set; }
        public DateTime DiscoveryDate { get; set; }
        public BugSeverity Severity { get; set; }
    }
}
