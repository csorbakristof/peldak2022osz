using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonTests
{
    public class NeptunBasedIdentityManagerTests
    {
        private TestingNeptunCodeValidator neptunCodeValidator;
        private NeptunBasedIdentityManager identityManager;

        public NeptunBasedIdentityManagerTests()
        {
            neptunCodeValidator = new();
            identityManager = new(neptunCodeValidator);
        }

        [Fact]
        public void GenerateIdentity_EmptyUsername()
        {
            Assert.Throws<ArgumentException>(() => identityManager.GenerateIdentity(string.Empty));
        }

        private const string username = "ABC123";
        private const string userID = "OK8KLBY";
        private const string password = "OISZH";
        private const string dummyString = "DUMMY";

        [Fact]
        public void GenerateIdentity_GivenUsername()
        {
            (string resultUserID, string resultPassword) = identityManager.GenerateIdentity(username);
            Assert.Equal(userID, resultUserID);
            Assert.Equal(password, resultPassword);
        }

        [Fact]
        public void IsAuthenticated_Correct()
        {
            Assert.True(identityManager.IsAuthenticated(userID, password));
            Assert.False(identityManager.IsAuthenticated(userID, dummyString));
        }

        [Fact]
        public void IsValid()
        {
            Assert.True(identityManager.IsValid(userID));
            Assert.False(identityManager.IsValid(dummyString));
        }

        [Fact]
        public void GenerateIdentity_CallsNeptunCodeValidator()
        {
            identityManager.GenerateIdentity(dummyString);
            Assert.True(neptunCodeValidator.Called);
        }

        private class TestingNeptunCodeValidator : NeptunCodeValidator
        {
            public bool Called = false;
            public override bool IsValid(string neptunCode)
            {
                Called = true;
                return true;
            }
        }
    }
}
