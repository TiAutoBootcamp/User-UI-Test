

using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;
using UserUITest.Support;

namespace UserUITest
{
    public  class DataContext
    {
     
        public int UserId;
        public int SecondUserId;
        public RegisterUserRequest CreateUserRequest;
        public CommonResponse<int> CreateUserStatusResponse;
        public bool ModalDisplayed;
        public bool UserStatus;
        public string BirthDayUser;
        public Guid UserIdTransaction;
        public UserModalInformation UserModalInformation;

    }
}
