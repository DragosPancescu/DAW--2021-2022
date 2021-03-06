using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.VersionRepository
{
    public interface IVersionRepository: IGenericRepository<ProjectVersion>
    {
        IEnumerable<ProjectVersion> FindByProjectId(Guid projectId);
        ProjectVersion FindByVersionNumbers(Guid projectId, int majorNumber, int minorNumber, int patchNumber);
    }
}
