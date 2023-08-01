using System.Globalization;

namespace Core
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public string BirthDate { get; set; }
    }

    }