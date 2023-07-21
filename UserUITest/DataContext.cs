﻿

using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;


namespace UserUITest
{
    public  class DataContext
    {
     
        public int UserId;
        public int SecondUserId;

        public RegisterUserRequest CreateUserRequest;
        public CommonResponse<int> CreateUserResponse;
        public CommonResponse<object> SetUserStatusResponse;
        public bool ModalDisplayed;
        public bool UserStatus;
        public Guid UserIdTransaction;
        public int IdModal;
        public string FirstNameModal;
        public string LastNameModal;
        public bool StatusModal;
        public string BirthDateModal;


    }
}
