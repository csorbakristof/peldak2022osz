using Core;

namespace CommonTests
{
    internal class DummyIdentityManager : IIdentityManager
    {
        public const string UserID = "username";
        public const string Password = "password";
        public const string ValidUserID2 = "username2";
        public const string InvalidPassword = "InvalidPassword";
        public const string InvalidUserID = "InvalidUserID";
        public bool GenerateIdentityCalled = false;
        public bool IsAuthenticatedCalled = false;
        public bool IsValidCalled = false;

        public (string userID, string password) GenerateIdentity(string username)
        {
            GenerateIdentityCalled = true;
            return (UserID, Password);
        }

        public bool IsAuthenticated(string userID, string password)
        {
            IsAuthenticatedCalled = true;
            return (userID==UserID && password==Password);
        }

        public bool IsValid(string userID)
        {
            IsValidCalled = true;
            return (userID == UserID || userID == ValidUserID2);
        }
    }
}
