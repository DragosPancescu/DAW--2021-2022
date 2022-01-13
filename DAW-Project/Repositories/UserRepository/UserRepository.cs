using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository 
    {
        public UserRepository(DawProjectContext context) : base(context)
        {

        }

        public User FindByUserName(string userName)
        {
            return _table.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
