using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal interface IIdentityManager
    {
        public (string userID, string password) GenerateIdentity(string username);

        public bool IsValid(string userID);
        public bool IsAuthenticated(string userID, string password);
    }
}
