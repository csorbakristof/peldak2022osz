using Core;
using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Database;
using WebApp.Server.Services;
using WebApp.Shared;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteQuestionController : ControllerBase
    {
        private readonly ReviewerServices service;

        public DeleteQuestionController(ReviewerServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Post(int id)
        {
            service.DeleteQuestion(id);
        }
    }
}
