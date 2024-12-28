using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationAuthorization.JwtModel
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;
        public Authorization(params Role[] roles) 
        {
            _roles = roles??new Role[] {  };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isRolePermission = false;
            Users user = (Users)context.HttpContext.Items["User"];
            if(user == null) 
            {
                context.Result = new JsonResult(new { message="Unauthorized",statusCode = StatusCodes.Status401Unauthorized});
            }
            if(user != null && _roles.Any()) 
            {
                foreach (var userRole in user.roles)
                {
                    foreach (var authrole in _roles)
                    {
                        if (userRole == authrole)
                        {
                            isRolePermission = true;
                        }
                    }
                }
            }
            if(!isRolePermission) 
            {
                context.Result = new JsonResult(new { message = "Unauthorized", statusCode = StatusCodes.Status401Unauthorized });
            }
        }
    }
}
