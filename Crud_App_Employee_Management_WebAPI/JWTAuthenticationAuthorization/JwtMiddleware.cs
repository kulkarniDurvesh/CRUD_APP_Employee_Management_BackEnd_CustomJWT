using JWTAuthenticationAuthorization.JwtModel;
using JWTAuthenticationAuthorization.JwtServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace JWTAuthenticationAuthorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleware(IOptions<AppSettings>appSettings,RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext httpContext, IUserService userService) 
        { 
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                attachUserToContext(httpContext, userService, token);
            }

            await _next(httpContext);
        }
        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try 
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_appSettings.Key));
                tokenhandler.ValidateToken(token, new TokenValidationParameters { 
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Issuer
                    
                },out SecurityToken validateToken);
                var jwtToken = (JwtSecurityToken)validateToken;
                var userId = int.Parse(jwtToken.Claims.FirstOrDefault(_claim => _claim.Type == "Id").Value);
                context.Items["User"] = userService.GetById(userId);
            }
            catch (Exception ex) 
            {
            
            }
        }
    }
}
