using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.VersionRepository
{
    public class VersionRepository: GenericRepository<ProjectVersion>, IVersionRepository
    {

        public VersionRepository(DawProjectContext context) : base(context)
        {

        }

        public IEnumerable<ProjectVersion> FindByProjectId(Guid projectId)
        {
            return _table.Where(x => x.ProjectId == projectId);
        }

        public ProjectVersion FindByVersionNumbers(Guid projectId, int majorNumber, int minorNumber, int patchNumber)
        {
            IQueryable<ProjectVersion> output = _table.Where(x => x.ProjectId == projectId);

            if (majorNumber >= 0)
                output = output.Where(x => x.MajorVersion == majorNumber);

            if (minorNumber >= 0)
                output = output.Where(x => x.MinorVersion == minorNumber);

            if (patchNumber >= 0)
                output = output.Where(x => x.PatchVersion == patchNumber);

            return output.FirstOrDefault();
        }
    }
}
