using Newtonsoft.Json;

namespace UserServiceAPI.Models.Requests
{
    public class RegisterUserRequest
    {
        [JsonProperty("firstName")]
        public string FirstName;

        [JsonProperty("lastName")]
        public string LastName;

        [JsonProperty("birthDate")]
        public string BirthDate;
    }
}
