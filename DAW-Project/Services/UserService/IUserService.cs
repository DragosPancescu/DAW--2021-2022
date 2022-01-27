using DAW_Project.Models;
using DAW_Project.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services
{
    public interface IUserService
    {
        // Auth
        UserResponseDTO Authenticate(UserRequestDTO model);

        // GetAll
        IEnumerable<User> GetAllUsers();

        // GetById
        User GetById(Guid id);

        // GetByUsername
        User GetByUserName(string userName);

        // GetAllBugReports
        IEnumerable<BugReport> GetAllBugReports(string userName);

        // Create
        void Create(User user);

        // Delete
        void Delete(User user);

        // Update
        void Update(User user);
    }
}
