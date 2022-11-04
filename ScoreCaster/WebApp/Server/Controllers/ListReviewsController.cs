using Core;
using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Database;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListReviewsController : Controller
    {
        private ScoreCasterDbContext context;

        public ListReviewsController(ScoreCasterDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Response> Get(string userID, string password)
        {
            // TODO: validate username and password
            // Filter on targetUserID
            return context.Question.SelectMany(q => q.GetResponses());
        }
    }
}
