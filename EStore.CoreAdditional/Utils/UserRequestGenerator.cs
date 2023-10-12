using Estore.Models.Request.User;
using System.Text;

namespace CoreAdditional.Utils
{
    public class UserRequestGenerator
    {
        public RegisterCustomerRequest GenerateUserRequest()
        {
            return GenerateCreateUserRequest("KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""));
        }

        public RegisterCustomerRequest GenerateCreateUserRequest(string firstName)
        {
            return GenerateCreateUserRequest(firstName, "Cucunuba" + Guid.NewGuid().ToString());
        }

        public RegisterCustomerRequest GenerateCreateUserRequest(string firstName, string lastName)
        {
            return new RegisterCustomerRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
            };
        }

        public RegisterCustomerRequest GenerateCreateUserRequestWithBirthDate(string birthDate)
        {
            var firstName = "KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            var lastName = "Cucunuba" + Guid.NewGuid().ToString();
            return new RegisterCustomerRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                BirthDate = DateTime.TryParse(birthDate, out DateTime parsedDate) ? (DateTime?)parsedDate : null
            };
        }

        public RegisterCustomerRequest GenerateCreateUserRequestWithBirthDate(string firstName, string lastName, string birthDate)
        {
            return new RegisterCustomerRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                BirthDate = DateTime.TryParse(birthDate, out DateTime parsedDate) ? (DateTime?)parsedDate : null
            };
        }

        public RegisterCustomerRequest GenerateRandomUserRequest(int length, string birthDate)
        {
            const string _string = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()/{";
            Random random = new Random();

            StringBuilder firstName = new StringBuilder();
            StringBuilder lastName = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(_string.Length);
                lastName.Append(_string[index]);
                index = random.Next(_string.Length);
                firstName.Append(_string[index]);
            }

            return GenerateCreateUserRequestWithBirthDate(firstName.ToString(), lastName.ToString(), birthDate);
        }

        public RegisterCustomerRequest GenerateRandomFirstNameWithGuidLastNameRequest(int length, string birthDate)
        {
            StringBuilder name = GenerateRandomString(length);
            return GenerateCreateUserRequestWithBirthDate(name.ToString(), "Cucunuba" + Guid.NewGuid().ToString(), birthDate);
        }

        public RegisterCustomerRequest GenerateRandomLastNameWithGuidLastNameRequest(int length, string birthDate)
        {
            StringBuilder name = GenerateRandomString(length);
            return GenerateCreateUserRequestWithBirthDate("KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""), name.ToString(), birthDate);
        }

        public StringBuilder GenerateRandomString(int length)
        {
            const string _string = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()/{";
            Random random = new Random();
            StringBuilder name = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(_string.Length);
                name.Append(_string[index]);
            }
            return name;
        }

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
