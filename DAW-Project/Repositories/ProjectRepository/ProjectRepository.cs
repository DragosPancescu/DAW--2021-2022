using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.ProjectRepository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {

        public ProjectRepository(DawProjectContext context): base(context)
        {

        }

        public Project FindByName(string name)
        {
            return _table.FirstOrDefault(x => x.ProjectName == name);
        }
    }
}
