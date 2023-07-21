using System.Text;
using System.Xml.Linq;
using UserServiceAPI.Models.Requests;

namespace UserServiceAPI.Utils
{
    public class UserGenerator
    {
        
        public RegisterUserRequest GenerateUserRequest()
        {
            return GenerateCreateUserRequest("KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""));
        }

        public RegisterUserRequest GenerateCreateUserRequest(string firstName)
        {
            return GenerateCreateUserRequest(firstName, "Cucunuba" + Guid.NewGuid().ToString());
        }

        public RegisterUserRequest GenerateCreateUserRequest(string firstName, string lastName)
        {
            return new RegisterUserRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
            };
        }

        public RegisterUserRequest GenerateCreateUserRequestWithBirthDate(string birthDate)
        {
            var firstName = "KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            var lastName = "Cucunuba" + Guid.NewGuid().ToString();
            return new RegisterUserRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                BirthDate = birthDate ?? "",
            };
        }

        public RegisterUserRequest GenerateCreateUserRequestWithBirthDate(string firstName, string lastName,string birthDate)
        {
            return new RegisterUserRequest()
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                BirthDate = birthDate ?? "",
            };
        }

        public RegisterUserRequest GenerateRandomUserRequest(int length, string birthDate)
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


        public RegisterUserRequest GenerateRandomFirstNameWithGuidLastNameRequest(int length, string birthDate)
        {
            StringBuilder name = GenerateRandomString(length);
            return GenerateCreateUserRequestWithBirthDate(name.ToString(), "Cucunuba" + Guid.NewGuid().ToString(),birthDate);
        }

        public RegisterUserRequest GenerateRandomLastNameWithGuidLastNameRequest(int length, string birthDate)
        {
            StringBuilder name = GenerateRandomString(length);
            return GenerateCreateUserRequestWithBirthDate("KCV" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""), name.ToString(), birthDate);
        }
        
        public StringBuilder GenerateRandomString(int length) {
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


        public int GenerateId() {
            Random random = new Random();
            int randomNumber = random.Next(0,10000000);
            return randomNumber;
        } 

    }
}
