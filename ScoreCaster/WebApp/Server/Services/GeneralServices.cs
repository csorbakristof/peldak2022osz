using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Server.Services
{
    public class GeneralServices
    {
        private IIdentityManager identityManager;
        public GeneralServices(IIdentityManager identityManager)
        {
            this.identityManager = identityManager;
        }

        public (string userID, string password) GenerateUserID(string username)
        {
            return identityManager.GenerateIdentity(username);
        }
    }
}
