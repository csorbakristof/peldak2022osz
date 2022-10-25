using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Shared;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateUserIdController : Controller
    {
        private GeneralServices services;

        public GenerateUserIdController()
        {
            this.services = new(new NeptunBasedIdentityManager(new NeptunCodeValidator()));
        }

        [HttpGet]
        public UserIdAndPassword Get(string? username)
        {
            (string u, string p) = services.GenerateUserID(username);
            return new UserIdAndPassword() { UserID = u, Password = p };
        }
    }
}
