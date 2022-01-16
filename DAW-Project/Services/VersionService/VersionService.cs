using DAW_Project.Models;
using DAW_Project.Repositories.VersionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.VersionService
{
    public class VersionService : IVersionService
    {
        public IVersionRepository _versionRepository;

        public VersionService(IVersionRepository versionRepository)
        {
            _versionRepository = versionRepository;
        }

        public IEnumerable<ProjectVersion> GetAllVersionsOfProject(Guid projectId)
        {
            var allVersions = _versionRepository.FindByProjectId(projectId);

            if (allVersions == null)
            {
                return null;
            }

            return allVersions;
        }

        public ProjectVersion GetByVersionNumbers(Guid projectId, int majorNumber, int minorNumber, int patchNumber)
        {
            var version = _versionRepository.FindByVersionNumbers(projectId, majorNumber, minorNumber, patchNumber);

            if (version == null)
            {
                return null;
            }

            return version;
        }

        public void Create(ProjectVersion projectVersion)
        {
            _versionRepository.Create(projectVersion);
            _versionRepository.Save();
        }

        public void Delete(ProjectVersion projectVersion)
        {
            _versionRepository.Delete(projectVersion);
            _versionRepository.Save();
        }

        public void Update(ProjectVersion projectVersion)
        {
            _versionRepository.Update(projectVersion);
            _versionRepository.Save();
        }
    }
}
