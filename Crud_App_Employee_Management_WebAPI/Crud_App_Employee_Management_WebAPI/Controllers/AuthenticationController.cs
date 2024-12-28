using JWTAuthenticationAuthorization.JwtModel;
using JWTAuthenticationAuthorization.JwtServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_App_Employee_Management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(AuthenticationRequest model)
        {
            var response = this.authenticationService.authenticate(model);
            if (response == null)
            {
                return new JsonResult(new { message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized });
            }
            else { 
                return Ok(response);
            }

        }
    }
}
