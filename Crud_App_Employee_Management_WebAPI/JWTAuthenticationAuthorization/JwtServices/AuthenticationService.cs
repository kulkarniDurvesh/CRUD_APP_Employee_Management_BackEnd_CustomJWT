using JWTAuthenticationAuthorization.JwtModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using RepositoryLayer.DataAccess;
using Models;



namespace JWTAuthenticationAuthorization.JwtServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;
        //private List<User> _users = new List<User>() {
        //    new User(){
        //        Id = 1,
        //        FirstName = "Test",
        //        LastName = "Test",
        //        Password = "Test",
        //        Email = "Test@gmail.com",
        //        UserName = "Test",
        //        roles = new List<Role>{Role.Customer }
        //    }
        //};
        private readonly DbConnection _connection;

        public AuthenticationService(IOptions<AppSettings> appSettings,DbConnection connection)
        {
            _appSettings = appSettings.Value;   
            _connection = connection;
        }

        public AuthenticationResponse authenticate(AuthenticationRequest request) 
        {
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();
            var user = _connection.users.FirstOrDefault(x=>x.UserName.Equals(request.UserName,StringComparison.OrdinalIgnoreCase) && x.Password == request.Password);
            if(user == null) 
            {
                return null;
            }
            var generatedToken = generateJwtToken(user);
            authenticationResponse.Token = generatedToken;
            return authenticationResponse;
        }
        private string generateJwtToken(Users user) 
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>() {
                new Claim("Id",Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,"Test"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                
            };
            foreach (var role in user.roles)
            {
                claims.Add(new Claim("Role", Convert.ToString(role)));
            }
            var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer, claims, expires: DateTime.Now.AddHours(1),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
