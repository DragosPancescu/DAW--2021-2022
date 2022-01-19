using DAW_Project.Services;
using DAW_Project.Utilities.JWTUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJWTUtils jWUtils)
        {
            // Bearer -token-
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userID = jWUtils.ValidateJWTToken(token);

            if (userID != Guid.Empty)
            {
                httpContext.Items["Users"] = userService.GetById(userID);
            }

            await _next(httpContext);
        }
    }
}
