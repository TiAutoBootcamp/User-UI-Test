using Estore.Models.Request.User;

namespace CoreAdditional.Utils
{
    public class UserRequestGenerator
    {
        public LoginRequest GenerateLoginRequest(string email, string password)
        {
            return new LoginRequest()
            {
                Email = email,
                Password = password
            };
        }
    }
}
