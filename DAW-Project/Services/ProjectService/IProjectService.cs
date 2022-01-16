using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.ProjectService
{
    public interface IProjectService
    {
        // GetAll
        IEnumerable<Project> GetAllProjects();

        // GetByName
        Project GetByName(string userName);

        // Create
        void Create(Project project);

        // Delete
        void Delete(Project project);

        // Update
        void Update(Project project);

    }
}
