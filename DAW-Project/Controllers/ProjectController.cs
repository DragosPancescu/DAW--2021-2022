using DAW_Project.Models;
using DAW_Project.Models.DTOs;
using DAW_Project.Models.DTOs.ProjectDTO;
using DAW_Project.Services.ProjectService;
using DAW_Project.Services.VersionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        private IVersionService _versionService;

        public ProjectController(IProjectService projectService, IVersionService versionService)
        {
            _projectService = projectService;
            _versionService = versionService;
        }

        [HttpPost("create_project")]
        public IActionResult Create(ProjectRequestDTO project)
        {
            if (project.ProjectName == null)
            {
                return BadRequest(new { Message = "Project name field should not be empty." });
            }

            var sameNameProject = _projectService.GetByName(project.ProjectName);
            if (sameNameProject != null)
            {
                return BadRequest(new { Message = "A project with the same name already exists, pick another one." });
            }

            var projectToCreate = new Project
            {
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                DateCreated = DateTime.Now
            };

            _projectService.Create(projectToCreate);
            return Ok(new { Message = "Project created with success." });
        }

        [HttpGet("get_all_projects")]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();

            if (projects == null)
            {
                return BadRequest(new { Message = "No projects found." });
            }

            return Ok(projects);
        }

        [HttpGet("get_project_by_name")]
        public IActionResult GetByName(string name)
        {
            var project = _projectService.GetByName(name);

            if (project == null)
            {
                return BadRequest(new { Message = "No project found with the ProjectName you provided." });
            }

            return Ok(project);
        }

        [HttpDelete("delete_project")]
        public IActionResult Delete(string name)
        {
            var projectToDelete = _projectService.GetByName(name);

            if (projectToDelete == null)
            {
                return BadRequest(new { Message = "No project found to delete." });
            }

            _projectService.Delete(projectToDelete);
            return Ok(new { Message = "Project deleted with success." });
        }

        [HttpPut("update_project_description")]
        public IActionResult UpdateDescription(ProjectRequestDTO project)
        {
            var projectToUpdate = _projectService.GetByName(project.ProjectName);

            if (projectToUpdate == null)
            {
                return BadRequest(new { Message = "No project found to update." });
            }

            // Implement changes
            projectToUpdate.ProjectDescription = project.ProjectDescription ?? projectToUpdate.ProjectDescription;
            projectToUpdate.DateModified = DateTime.Now;

            _projectService.Update(projectToUpdate);
            return Ok(new { Message = "Project description updated with success." });
        }

        [HttpPut("update_project_name")]
        public IActionResult UpdateName(string oldProjectName, string newProjectName)
        {
            var projectToUpdate = _projectService.GetByName(oldProjectName);

            if (projectToUpdate == null)
            {
                return BadRequest(new { Message = "No project found to update." });
            }

            // Implement changes
            projectToUpdate.ProjectName = newProjectName;
            projectToUpdate.DateModified = DateTime.Now;

            _projectService.Update(projectToUpdate);
            return Ok(new { Message = "Project name updated with success." });
        }

        // #################### Version ####################

        [HttpPost("Version/create_version")]
        public IActionResult CreateVersion(VersionRequestDTO version)
        {
            if (version.ProjectId == Guid.Empty)
            {
                return BadRequest(new { Message = "Project ID field should not be empty." });
            }

            var sameNumberedVersion = _versionService.GetByVersionNumbers(version.ProjectId, 
                                                                          majorNumber: version.MajorVersion,   
                                                                          minorNumber: version.MinorVersion,
                                                                          patchNumber: version.PatchVersion);

            if (sameNumberedVersion != null)
            {
                return BadRequest(new { Message = "This version already exists for the given Project ID" });
            }

            var versionToCreate = new ProjectVersion
            {
                ProjectId = version.ProjectId,
                LaunchDate = version.LaunchDate,
                MajorVersion = version.MajorVersion,
                MinorVersion = version.MinorVersion,
                PatchVersion = version.PatchVersion,
                DateCreated = DateTime.Now
            };

            _versionService.Create(versionToCreate);
            return Ok(new { Message = "Version created with success." });
        }

        [HttpGet("Version/get_all_versions")]
        public IActionResult GetAllVersions(Guid projectId)
        {
            var versions = _versionService.GetAllVersionsOfProject(projectId);

            if (versions == null)
            {
                return BadRequest(new { Message = "No versions found." });
            }

            return Ok(versions);
        }

        [HttpGet("Version/get_version")]
        public IActionResult GetAllVersions(Guid projectId, int majorNumber = 0, int minorNumber = 0, int patchNumber = 0)
        {
            var version = _versionService.GetByVersionNumbers(projectId,
                                                              majorNumber: majorNumber,
                                                              minorNumber: minorNumber,
                                                              patchNumber: patchNumber);

            if (version == null)
            {
                return BadRequest(new { Message = "No version found." });
            }

            return Ok(version);
        }

        [HttpDelete("Version/delete_version")]
        public IActionResult DeleteVersion(VersionRequestDTO version)
        {
            // Searching for the version
            var versionToDelete = _versionService.GetByVersionNumbers(version.ProjectId,
                                                                      majorNumber: version.MajorVersion,
                                                                      minorNumber: version.MinorVersion,
                                                                      patchNumber: version.PatchVersion);

            if (versionToDelete == null)
            {
                return BadRequest(new { Message = "No version found to delete." });
            }

            _versionService.Delete(versionToDelete);
            return Ok(new { Message = "Version deleted with success." });
        }

        // TO DO: Add update for version
        //[HttpPut("update_project_name")]
    }
}
