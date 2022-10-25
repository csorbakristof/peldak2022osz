using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddReviewController : Controller
    {
        private ReviewerServices service;

        public AddReviewController()
        {
            this.service = Program.ServerSideDataAndServices.ReviewerServices;
        }

        [HttpGet]
        public void Post(string userid, string password, string targetUserID, int questionID, int score, string? comment)
        {
            service.AddResponse(userid, password, targetUserID, questionID, score, comment);
        }
    }
}
