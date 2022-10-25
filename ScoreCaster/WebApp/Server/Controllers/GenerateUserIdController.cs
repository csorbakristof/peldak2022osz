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
        private GeneralServices service;

        public GenerateUserIdController()
        {
            this.service = Program.ServerSideDataAndServices.GeneralServices;
        }

        [HttpGet]
        public UserIdAndPassword Get(string? username)
        {
            (string u, string p) = service.GenerateUserID(username);
            return new UserIdAndPassword() { UserID = u, Password = p };
        }
    }
}
