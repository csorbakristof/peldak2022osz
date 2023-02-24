using Core;
using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Database;
using WebApp.Server.Services;
using WebApp.Shared;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddQuestionController : ControllerBase
    {
        private readonly ReviewerServices service;

        public AddQuestionController(ReviewerServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Post(string text)
        {
            service.AddQuestion(text);
        }
    }
}
