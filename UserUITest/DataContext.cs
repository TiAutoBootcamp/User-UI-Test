

using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;

namespace UserUITest
{
    public  class DataContext
    {
     
        public int UserId;
        public int SecondUserId;
        public RegisterUserRequest CreateUserRequest;
        public CommonResponse<int> CreateUserStatusResponse;
        public bool ModalDisplayed;
        public Guid UserIdTransaction;

    }
}
