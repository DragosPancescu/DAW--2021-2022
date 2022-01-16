using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.VersionService
{
    public interface IVersionService
    {
        // GetAll 
        IEnumerable<ProjectVersion> GetAllVersionsOfProject(Guid projectId);

        // GetByVersionNumbers
        ProjectVersion GetByVersionNumbers(Guid projectId, int majorNumber = 0, int minorNumber = 0, int patchNumber = 0);

        // Create
        void Create(ProjectVersion projectVersion);

        // Delete
        void Delete(ProjectVersion projectVersion);

        // Update
        void Update(ProjectVersion projectVersion);
    }
}
