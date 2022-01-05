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
                return BadRequest(new { Message = "Username or Password is invalid" });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                FirstName = user.FirstName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            return Ok();
        }

        // [AllowAnonymous]
        [Authorization(Role.Admin)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
