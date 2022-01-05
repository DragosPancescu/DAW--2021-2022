using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Models.DTOs;
using DAW_Project.Utilities;
using DAW_Project.Utilities.JWTUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DAW_Project.Services
{
    public class UserService : IUserService
    {
        public DawProjectContext _dawProjectContext;
        private IJWTUtils _iJWTUtils;
        private readonly AppSettings _appSettings;

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _dawProjectContext.Users.FirstOrDefault(x => x.UserName == model.UserName);

            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            // Generate Token
            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
