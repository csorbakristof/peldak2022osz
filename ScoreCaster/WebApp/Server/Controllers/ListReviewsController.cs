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
        private IIdentityManager identityManager;

        public ListReviewsController(ScoreCasterDbContext context, IIdentityManager identityManager)
        {
            this.context = context;
            this.identityManager = identityManager;
        }

        [HttpGet]
        public IEnumerable<Response> Get(string userID, string password)
        {
            if (!identityManager.IsAuthenticated(userID, password))
                throw new UnauthorizedAccessException("Invalid userID and/or password...");
            return context.Question.SelectMany(q => q.Responses).Where(r=>r.TargetUserID == userID);
        }
    }
}
