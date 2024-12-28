using JWTAuthenticationAuthorization.JwtModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationAuthorization.JwtServices
{
    public interface IAuthenticationService
    {
        AuthenticationResponse authenticate(AuthenticationRequest authenticationRequest);
    }
}
