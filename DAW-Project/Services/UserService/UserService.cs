using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Models.DTOs;
using DAW_Project.Repositories.UserRepository;
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
        private readonly IJWTUtils _iJWTUtils;
        public IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUserName(model.UserName);

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
            var allUsers = _userRepository.GetAllAsQueryable();

            if (allUsers == null)
            {
                return null;
            }

            return allUsers;
        }

        public User GetById(Guid id)
        {
            var user = _userRepository.FindById(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public User GetByUserName(string userName)
        {
            var user = _userRepository.FindByUserName(userName);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
            _userRepository.Save();
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
            _userRepository.Save();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }
    }
}
