using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListReviewsController : Controller
    {
        [HttpGet]
        public IEnumerable<Response> Get(string userID, string password)
        {
            // TODO: validate username and password
            // Filter on targetUserID
            return Program.ServerSideDataAndServices.Questions.SelectMany(q => q.GetResponses());
        }
    }
}
