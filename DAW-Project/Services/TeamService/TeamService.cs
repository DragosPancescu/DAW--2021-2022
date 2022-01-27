using DAW_Project.Models;
using DAW_Project.Repositories.TeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            var allTeams = _teamRepository.GetAllAsQueryable();

            if (allTeams == null)
            {
                return null;
            }

            return allTeams;
        }

        public Team GetById(Guid id)
        {
            var team = _teamRepository.FindById(id);

            if (team == null)
            {
                return null;
            }

            return team;
        }

        public Team GetByTeamName(string teamName)
        {
            var team = _teamRepository.FindByTeamName(teamName);

            if (team == null)
            {
                return null;
            }

            return team;
        }

        public void Create(Team team)
        {
            _teamRepository.Create(team);
            _teamRepository.Save();
        }

        public void Delete(Team team)
        {
            _teamRepository.Delete(team);
            _teamRepository.Save();
        }

        public void Update(Team team)
        {
            _teamRepository.Update(team);
            _teamRepository.Save();
        }
    }
}
