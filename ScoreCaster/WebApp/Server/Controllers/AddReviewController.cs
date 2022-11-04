using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Services;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddReviewController : Controller
    {
        private ReviewerServices service;

        public AddReviewController(ReviewerServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Post(string userid, string password, string targetUserID, int questionID, int score, string? comment)
        {
            service.AddResponse(userid, password, targetUserID, questionID, score, comment);
        }
    }
}
