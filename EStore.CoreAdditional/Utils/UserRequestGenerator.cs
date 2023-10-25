using Bogus;
using Estore.Models.DataModels.User;
using Estore.Models.Enum;
using Estore.Models.Request.User;
using System.Text;

namespace CoreAdditional.Utils
{
    public class UserRequestGenerator
    {
        private Faker _faker = new Faker();
        private readonly string _lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private readonly string _upperСaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _digits = "0123456789";

        public RegisterCustomerRequest GenerateRegisterNewUserRequest(
             string firstName = "faker",
             string lastName = "faker",
             string dateOfBirth = "faker",
             string password = "faker",
             string email = "faker",
             string format = "dd.MM.yyyy")
        {
            return new RegisterCustomerRequest()
            {
                FirstName = firstName == "faker" ? _faker.Name.FirstName() : firstName,
                LastName = lastName == "faker" ? _faker.Name.LastName() : lastName,
                BirthDate = dateOfBirth == "faker" ? DateTime.ParseExact(GenerateValidBirthdayWithDots(), format, null)
                    : DateTime.ParseExact(dateOfBirth, format, null),
                Password = password == "faker" ? GenerateValidPassword() : password,
                Email = email == "faker" ? GenerateEmail() : email
            };
        }
                
        public string GenerateValidPassword()
        {
            var password = new StringBuilder();
            password
                .Append(_faker.Internet.Password(4))
                .Append(_faker.Random.String2(2, _lowerCaseLetters))
                .Append(_faker.Random.String2(2, _upperСaseLetters))
                .Append(_faker.Random.String2(2, _digits));
            return password.ToString();
        }

        public string GenerateInvalidPasswordWith1Letter()
        {
            return _faker.Internet.Password(1);
        }

        public string GenerateInvalidPasswordWithMoreThan32Letters()
        {
            var password = _faker.Internet.Password(33);
            return password;
        }

        public string GenerateInvalidPasswordWithoutLowerCaseLetters()
        {
            var password = new StringBuilder();
            password
                .Append(_faker.Random.String2(2, _upperСaseLetters))
                .Append(_faker.Random.String2(2, _digits));
            return password.ToString();
        }

        public string GenerateInvalidPasswordWithoutUpperCaseLetters()
        {
            var password = new StringBuilder();
            password
                .Append(_faker.Random.String2(2, _lowerCaseLetters))
                .Append(_faker.Random.String2(2, _digits));
            return password.ToString();
        }

        public string GenerateInvalidPasswordWithoutDigits()
        {
            var password = new StringBuilder();
            password
                .Append(_faker.Random.String2(3, _lowerCaseLetters))
                .Append(_faker.Random.String2(3, _upperСaseLetters));
            return password.ToString();
        }


        public string GenerateValidBirthdayWithDots()
        {
            var day = _faker.Random.Int(1, 28);
            var month = _faker.Random.Int(1, 12);
            var currentYear = DateTime.Now.Year;
            var minYear = currentYear - 129;
            var maxYear = currentYear - 6;
            var year = _faker.Random.Int(minYear, maxYear);
            return $"{day:D2}.{month:D2}.{year}";
        }

        public string GenerateEmail()
        {
            return _faker.Internet.Email();
        }

        public LoginRequest GenerateLoginRequest(string email, string password)
        {
            return new LoginRequest()
            {
                Email = email,
                Password = password
            };
        }

        public UserModel GenerateNewCustomerModel()
        {
            return new UserModel()
            {
                MainInfo = new CustomerUserMainInfo
                {
                    FirstName = Guid.NewGuid().ToString(),
                    LastName = Guid.NewGuid().ToString()                    
                },
                Credentials = new UserCredentials
                {
                    Email = GenerateEmail(),
                    Password = GenerateValidPassword(),
                    Role = UserRole.Customer
                }
            };
        }

    }
}
