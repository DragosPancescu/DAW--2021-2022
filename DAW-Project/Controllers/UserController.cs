using DAW_Project.Models;
using DAW_Project.Models.DTOs;
using DAW_Project.Services;
using DAW_Project.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid." });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create(UserRequestDTO user)
        {
            var sameUsernameUsers = _userService.GetByUserName(user.UserName);
            if (sameUsernameUsers != null)
            {
                return BadRequest(new { Message = "Username is already used, pick another one." });
            }

            var userToCreate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            _userService.Create(userToCreate);
            return Ok(new { Message = "User created with success." });
        }

        //[Authorization(Role.Admin)]
        [HttpGet("getAll")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            if (users == null)
            {
                return BadRequest(new { Message = "No users found." });
            }
            return Ok(users);
        }

        [HttpGet("getById")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return BadRequest(new { Message = "No user found with the id you provided." });
            }

            UserResponseDTO userResponse = new UserResponseDTO(user, "don't know");
            return Ok(userResponse);
        }

        [HttpGet("getByUsername")]
        public IActionResult GetByUserName(string userName)
        {
            var user = _userService.GetByUserName(userName);

            if (user == null)
            {
                return BadRequest(new { Message = "No user found with the Username you provided." });
            }

            UserResponseDTO userResponse = new UserResponseDTO(user, "don't know");
            return Ok(userResponse);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(UserRequestDTO user)
        {
            var userToDelete = _userService.GetByUserName(user.UserName);

            if (userToDelete == null)
            {
                return BadRequest(new { Message = "No user found to delete." });
            }

            _userService.Delete(userToDelete);
            return Ok(new { Message = "User deleted with success." });
        }

        // TO DO: Update
        [HttpPut("update")]
        public IActionResult Update(UserRequestDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
