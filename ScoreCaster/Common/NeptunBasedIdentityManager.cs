using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class NeptunBasedIdentityManager : IIdentityManager
    {
        public (string userID, string password) GenerateIdentity(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(string userID, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
