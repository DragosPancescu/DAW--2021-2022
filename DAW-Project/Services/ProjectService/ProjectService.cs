using DAW_Project.Models;
using DAW_Project.Repositories.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.ProjectService
{
    public class ProjectService: IProjectService
    {
        public IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var allProjects = _projectRepository.GetAllAsQueryable();

            if (allProjects == null)
            {
                return null;
            }

            return allProjects;
        }

        public Project GetByName(string name)
        {
            var project = _projectRepository.FindByName(name);

            if (project == null)
            {
                return null;
            }

            return project;
        }

        public void Create(Project project)
        {
            _projectRepository.Create(project);
            _projectRepository.Save();
        }

        public void Delete(Project project)
        {
            _projectRepository.Delete(project);
            _projectRepository.Save();
        }

        public void Update(Project project)
        {
            _projectRepository.Update(project);
            _projectRepository.Save();
        }
    }
}
