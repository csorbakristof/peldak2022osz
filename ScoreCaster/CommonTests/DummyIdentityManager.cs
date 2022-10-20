using Common;

namespace CommonTests
{
    internal class DummyIdentityManager : IIdentityManager
    {
        public const string Username = "username";
        public const string Password = "password";

        public bool GenerateIdentityCalled = false;
        public bool IsAuthenticatedCalled = false;
        public bool IsValidCalled = false;

        public (string userID, string password) GenerateIdentity(string username)
        {
            GenerateIdentityCalled = true;
            return (Username, Password);
        }

        public bool IsAuthenticated(string userID, string password)
        {
            IsAuthenticatedCalled = true;
            return (userID==Username && password==Password);
        }

        public bool IsValid(string userID)
        {
            IsValidCalled = true;
            return (userID == Username);
        }
    }
}
