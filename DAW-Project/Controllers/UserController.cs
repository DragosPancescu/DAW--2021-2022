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
            if (user.UserName == null)
            {
                return BadRequest(new { Message = "Username field should not be empty." });
            }

            var sameUsernameUser = _userService.GetByUserName(user.UserName);
            if (sameUsernameUser != null)
            {
                return BadRequest(new { Message = "Username is already used, pick another one." });
            }

            var userToCreate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password),
                DateCreated = DateTime.Now
            };

            _userService.Create(userToCreate);
            return Ok(new { Message = "User created with success." });
        }

        //[Authorization(Role.Admin)]
        [HttpGet("get_all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            if (users == null)
            {
                return BadRequest(new { Message = "No users found." });
            }
            return Ok(users);
        }

        [HttpGet("get_by_id")]
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

        [HttpGet("get_by_username")]
        public IActionResult GetByUserName(string username)
        {
            var user = _userService.GetByUserName(username);

            if (user == null)
            {
                return BadRequest(new { Message = "No user found with the Username you provided." });
            }

            UserResponseDTO userResponse = new UserResponseDTO(user, "don't know");
            return Ok(userResponse);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string username)
        {
            var userToDelete = _userService.GetByUserName(username);

            if (userToDelete == null)
            {
                return BadRequest(new { Message = "No user found to delete." });
            }

            _userService.Delete(userToDelete);
            return Ok(new { Message = "User deleted with success." });
        }

        
        [HttpPut("update_no_username")]
        public IActionResult Update(UserRequestDTO user)
        {
            var userToUpdate = _userService.GetByUserName(user.UserName);

            if (userToUpdate == null)
            {
                return BadRequest(new { Message = "No user found to update." });
            }

            // Implement changes
            userToUpdate.LastName = user.LastName ?? userToUpdate.LastName;
            userToUpdate.FirstName = user.FirstName ?? userToUpdate.FirstName;
            userToUpdate.PasswordHash = user.Password == null ? userToUpdate.PasswordHash : BCryptNet.HashPassword(user.Password);
            userToUpdate.DateModified = DateTime.Now;

            _userService.Update(userToUpdate);
            return Ok(new { Message = "User updated with success." });
        }

        [HttpPut("update_username")]
        public IActionResult UpdateUsername(string oldUsername, string newUsername)
        {
            var userToUpdate = _userService.GetByUserName(oldUsername);

            if (userToUpdate == null)
            {
                return BadRequest(new { Message = "No user found to update." });
            }

            // Implement changes
            userToUpdate.UserName = newUsername;
            userToUpdate.DateModified = DateTime.Now;

            _userService.Update(userToUpdate);
            return Ok(new { Message = "Username updated with success." });
        }
    }
}
