using DAW_Project.Models;
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
            var unauthorizationStatusCodeObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized};

            if (_roles == null)
            {
                context.Result = unauthorizationStatusCodeObject;
            }

            var user = (User)context.HttpContext.Items["User"];
            // If the user has the required role.
            if (user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizationStatusCodeObject;
            }
        }
    }
}
