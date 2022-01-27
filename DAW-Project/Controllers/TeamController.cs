using DAW_Project.Models;
using DAW_Project.Models.DTOs.TeamDTO;
using DAW_Project.Services.TeamService;
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
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamController (ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("create")]
        public IActionResult Create(TeamRequestDTO team)
        {
            var sameTeamName = _teamService.GetByTeamName(team.TeamName);
            if (sameTeamName != null)
            {
                return BadRequest(new { Message = "Team name is already used, pick another one." });
            }

            var teamToCreate = new Team
            {
                TeamName = team.TeamName,
                Department = team.Department,
                LeadId = team.LeadId,
                DateCreated = DateTime.Now
            };

            _teamService.Create(teamToCreate);
            return Ok(new { Message = "Team created with success." });
        }

        [HttpGet("get_all")]
        public IActionResult GetAllTeams()
        {
            var teams = _teamService.GetAllTeams();
            if (teams == null)
            {
                return BadRequest(new { Message = "No teams found." });
            }
            return Ok(teams);
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById(Guid id)
        {
            var team = _teamService.GetById(id);

            if (team == null)
            {
                return BadRequest(new { Message = "No team found with the id you provided." });
            }

            return Ok(team);
        }

        [HttpGet("get_by_team_name")]
        public IActionResult GetByTeamName(string teamName)
        {
            var team = _teamService.GetByTeamName(teamName);

            if (team == null)
            {
                return BadRequest(new { Message = "No team found with the name you provided." });
            }

            return Ok(team);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string teamName)
        {
            var teamToDelete = _teamService.GetByTeamName(teamName);

            if (teamToDelete == null)
            {
                return BadRequest(new { Message = "No team found to delete." });
            }

            _teamService.Delete(teamToDelete);
            return Ok(new { Message = "Team deleted with success." });
        }

        [HttpPut("update_name")]
        public IActionResult UpdateName(string oldName, string newName)
        {
            var teamToUpdate = _teamService.GetByTeamName(oldName);

            if (teamToUpdate == null)
            {
                return BadRequest(new { Message = "No team found to update." });
            }

            teamToUpdate.TeamName = newName;
            teamToUpdate.DateModified = DateTime.Now;

            _teamService.Update(teamToUpdate);
            return Ok(new { Message = "Team name updated with success." });
        }
    }
}
