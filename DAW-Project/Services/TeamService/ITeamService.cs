using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.TeamService
{
    public interface ITeamService
    {
        // GetAll
        IEnumerable<Team> GetAllTeams();

        // GetById
        Team GetById(Guid id);

        // GetByTeamName
        Team GetByTeamName(string teamName);

        // Create
        void Create(Team team);

        // Delete
        void Delete(Team team);

        // Update
        void Update(Team team);
    }
}
