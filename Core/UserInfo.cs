using System.Globalization;

namespace Core
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        private string _birthDate;
        public string BirthDate
        {
            get => _birthDate;
            set => _birthDate = value == "empty" ? null : value;
        }
    }

    }