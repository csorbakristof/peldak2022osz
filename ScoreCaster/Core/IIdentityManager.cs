using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IIdentityManager
    {
        (string userID, string password) GenerateIdentity(string username);

        bool IsValid(string userID);
        bool IsAuthenticated(string userID, string password);
    }
}
