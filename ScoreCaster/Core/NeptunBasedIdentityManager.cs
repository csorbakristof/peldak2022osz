using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NeptunBasedIdentityManager : IIdentityManager
    {
        // UserID consists of hash from Neptun code (=part1) + salted hash of part2 (=part2)
        // Password is salted hash of UserID
        private const string usernameSalt = "lizzard";
        private const string userIdSalt = "spock";
        private const string passwordSalt = "rock";
        private const int userIdPart1Length = 5;
        private const int userIdPart2Length = 2;

        private SHA1 sha = SHA1.Create();
        private NeptunCodeValidator neptunCodeValidator;

        public NeptunBasedIdentityManager(NeptunCodeValidator neptunCodeValidator)
        {
            this.neptunCodeValidator = neptunCodeValidator;
        }

        public (string userID, string password) GenerateIdentity(string neptunCode)
        {
            if (neptunCode.Equals(string.Empty))
                throw new ArgumentException("username cannot be empty");
            neptunCode = neptunCode.ToUpper();
            if (!neptunCodeValidator.IsValid(neptunCode))
                throw new ArgumentException($"Invalid neptun code: {neptunCode}");
            var userID = GetUserIdFromUsername(neptunCode);
            var password = GetHashBeginning(userID, passwordSalt);
            return (userID, password);
        }

        private string GetUserIdFromUsername(string username)
        {
            var part1 = GetHashBeginning(username, usernameSalt, userIdPart1Length);
            var part2 = GetHashBeginning(part1, userIdSalt, userIdPart2Length);
            return part1 + part2;
        }

        private string GetHashBeginning(string text, string salt, int length=5)
        {
            return string.Concat(Convert.ToBase64String(this.sha.ComputeHash(Encoding.UTF8.GetBytes(text + salt)))
                .ToUpper().Where(c => char.IsLetterOrDigit(c)).Take(length));
        }

        public bool IsAuthenticated(string userID, string password)
        {
            return (GetHashBeginning(userID, passwordSalt).Equals(password));
        }

        public bool IsValid(string userID)
        {
            if (userID.Length != userIdPart1Length + userIdPart2Length)
                return false;
            var part1 = userID.Substring(0, userIdPart1Length);
            var part2 = userID.Substring(userIdPart1Length, userIdPart2Length);
            var correctPart2 = GetHashBeginning(part1, userIdSalt, userIdPart2Length);
            return (part2.Equals(correctPart2));
        }
    }
}
