namespace CoreAdditional
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
            get => _birthDate ?? string.Empty;
            set => _birthDate = value ?? string.Empty;
        }
    }
}