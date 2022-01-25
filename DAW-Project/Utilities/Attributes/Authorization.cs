using DAW_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Utilities
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;
        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            JsonResult unauthorizationStatusCodeObject;

            if (_roles == null)
            {
                unauthorizationStatusCodeObject = new JsonResult(new { Message = "Unauthorized - 1" })
                { StatusCode = StatusCodes.Status401Unauthorized };

                context.Result = unauthorizationStatusCodeObject;
            }

            var user = (User)context.HttpContext.Items["Users"];
            if (user.Role == Role.Admin)
            {
                return;
            }

            // If the user has the required role.
            if (user == null)
            {
                unauthorizationStatusCodeObject = new JsonResult(new { Message = "Unauthorized - 2" })
                { StatusCode = StatusCodes.Status401Unauthorized };

                context.Result = unauthorizationStatusCodeObject;
                return;
            }

            if (!_roles.Contains(user.Role))
            {
                unauthorizationStatusCodeObject = new JsonResult(new { Message = "Unauthorized - 3" })
                { StatusCode = StatusCodes.Status401Unauthorized };

                context.Result = unauthorizationStatusCodeObject;
            }
        }
    }
}
