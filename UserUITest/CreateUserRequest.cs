using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserServiceAPI.Client;
using UserServiceAPI.Utils;

namespace UserUITest
{
    public class CreateUserRequest
    {
        private readonly UserServiceClient _registerUser = new UserServiceClient();
        private readonly UserGenerator _userGenerator = new UserGenerator();
        private readonly DataContext _context = new DataContext();
        public async Task CreateGUIDUser()
        {

            _context.CreateUserRequest = _userGenerator.GenerateCreateUserRequest();
            _context.CreateUserStatusResponse = await _registerUser.CreateUser(_context.CreateUserRequest);

            
        }
       
    }
}
