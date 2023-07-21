﻿using NUnit.Framework;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class UserStepsAssertions
    {
        private readonly DataContext _context;
    
        public UserStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"the information on the modal match with the complete user name, ([^']*) and ([^']*)")]
        public void ThenTheInformationOnTheModalMatchWithTheUser(bool expectedStatus , string expectedBirthDate)
        {
            _context.UserStatus = expectedStatus;
          
            Assert.Multiple(()=>{
                Assert.That(_context.UserInfo.Id, Is.EqualTo(_context.InitialUserId));
                Assert.That(_context.UserInfo.FirstName, Is.EqualTo(_context.CreateUserRequest.FirstName));
                Assert.That(_context.UserInfo.LastName, Is.EqualTo(_context.CreateUserRequest.LastName));
                Assert.That(_context.UserInfo.IsActive, Is.EqualTo(_context.UserStatus));
                Assert.That(_context.UserInfo.BirthDate, Is.EqualTo(_context.CreateUserRequest.BirthDate));
            });
        }

        [Then(@"a modal with details is opened")]
        public void ThenAModalWithDetailsIsOpened()
        {
            Assert.IsTrue(_context.UserPage.IsModalDisplayed());
        }
    }
}