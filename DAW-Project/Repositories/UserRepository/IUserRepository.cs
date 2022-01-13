using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public User FindByUserName(string userName);
    }
}
