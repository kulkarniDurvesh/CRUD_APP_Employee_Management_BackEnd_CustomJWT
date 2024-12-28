using JWTAuthenticationAuthorization.JwtModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationAuthorization.JwtServices
{
    public interface IUserService
    {
        Users GetById(int id);
        IEnumerable<Users> GetAll();
    }
}
