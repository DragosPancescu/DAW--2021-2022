using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.TeamRepository
{
    public class TeamRepository: GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(DawProjectContext context) : base(context)
        {

        }

        public Team FindByTeamName(string teamName)
        {
            return _table.FirstOrDefault(x => x.TeamName == teamName);
        }
    }
}
