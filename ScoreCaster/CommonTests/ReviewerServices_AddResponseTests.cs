using Common;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonTests
{
    public class ReviewerServices_AddResponseTests
    {
        private readonly QuestionsContainer container = new QuestionsContainer();
        private readonly DummyIdentityManager identityManager = new DummyIdentityManager();
        private readonly ReviewerServices service;

        const int questionID = 1;
        const int score = 1;

        public ReviewerServices_AddResponseTests()
        {
            service = new ReviewerServices(container, identityManager);
            container.Questions.Add(new Question() { ID = questionID, MinResponseLength = 0, Text = String.Empty });
        }

        [Fact]
        public void AddResponse_Valid()
        {
            service.AddResponse(DummyIdentityManager.UserID, DummyIdentityManager.Password, DummyIdentityManager.ValidUserID2,
                questionID, score, string.Empty);
        }

        [Fact]
        public void AddResponse_InvalidSourceUserId()
        {
            Assert.Throws<ArgumentException>( ()=>service.AddResponse(
                DummyIdentityManager.InvalidUserID, DummyIdentityManager.InvalidPassword, DummyIdentityManager.ValidUserID2,
                questionID, score, string.Empty));
        }

        [Fact]
        public void AddResponse_InValidPassword()
        {
            Assert.Throws<ArgumentException>(() => service.AddResponse(
                DummyIdentityManager.UserID, DummyIdentityManager.InvalidPassword, DummyIdentityManager.ValidUserID2,
                questionID, score, string.Empty));
        }

        [Fact]
        public void AddResponse_InvalidTargetUserId()
        {
            Assert.Throws<ArgumentException>(() => service.AddResponse(
                DummyIdentityManager.UserID, DummyIdentityManager.Password, DummyIdentityManager.InvalidUserID,
                questionID, score, string.Empty));
        }
    }
}
