using Microsoft.AspNetCore.Mvc;
using WebApp.Shared;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateUserIdController : Controller
    {
        [HttpGet]
        public UserIdAndPassword Get(string? username)
        {
            return new UserIdAndPassword() { UserID = username ?? "UNKNOWN", Password = "PWD" };
        }
    }
}
