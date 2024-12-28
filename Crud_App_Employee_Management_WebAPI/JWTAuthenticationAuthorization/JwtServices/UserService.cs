using JWTAuthenticationAuthorization.JwtModel;
using Models;
using RepositoryLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationAuthorization.JwtServices
{
    public class UserService : IUserService
    {
        //private List<Users> _users = new List<Users>() {
        //    new Users{
        //        Id = 1,
        //        FirstName = "myTest",
        //        LastName = "User1",
        //        //role = new List<Role>{Role.Customer},
        //        UserName = "mytestuser",
        //        Password = "test123"

        //    },
        //    new Users{
        //        Id=2,
        //        FirstName = "myTest2",
        //        LastName = "User2",
        //        //role= new List<Role>{Role.Admin},
        //        UserName = "test",
        //        Password = "test"
        //    }
        //};
        private readonly DbConnection _connection;
        public UserService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Users> GetAll()
        {
            return _connection.users;
        }

        public Users GetById(int id)
        {
            return _connection.users.FirstOrDefault(x => x.Id == id);
        }
    }
}
