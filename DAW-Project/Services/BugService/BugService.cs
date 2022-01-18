using DAW_Project.Models;
using DAW_Project.Models.CustomTypes;
using DAW_Project.Repositories.BugRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.BugService
{
    public class BugService : IBugService
    {
        public IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public IEnumerable<BugReport> GetAllBugsOfVersion(Guid versionId)
        {
            var allBugs = _bugRepository.GetAllAsQueryable().Where(x => x.VersionId == versionId);

            if (allBugs == null)
            {
                return null;
            }

            return allBugs;
        }

        public IEnumerable<BugReport> GetBySeverity(Guid versionId, BugSeverity severity)
        {
            var allBugs = _bugRepository.GetAllAsQueryable().Where(x => x.VersionId == versionId && x.Severity == severity);

            if (allBugs == null)
            {
                return null;
            }

            return allBugs;
        }

        public BugReport GetById(Guid bugId)
        {
            var bug = _bugRepository.FindById(bugId);

            if (bug == null)
            {
                return null;
            }

            return bug;
        }

        public void Create(BugReport bug)
        {
            _bugRepository.Create(bug);
            _bugRepository.Save();
        }

        public void Delete(BugReport bug)
        {
            _bugRepository.Delete(bug);
            _bugRepository.Save();
        }

        public void Update(BugReport bug)
        {
            _bugRepository.Update(bug);
            _bugRepository.Save();
        }
    }
}
