using Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Server.Database;

namespace WebApp.Server.Services
{
    public class ReviewerServices
    {
        private ScoreCasterDbContext context;
        private IIdentityManager identityManager;

        public ReviewerServices(ScoreCasterDbContext context, IIdentityManager identityManager)
        {
            this.context = context;
            this.identityManager = identityManager;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return context.Question.ToList();
        }

        public void AddResponse(string sourceUserID, string sourceUserPassword,
            string targetUserID, int questionID, int score, string comment)
        {
            var question = this.context.Question.SingleOrDefault(q => q.ID == questionID);
            if (question == null)
                throw new ArgumentException($"Unknown question ID: {questionID}");
            if (!identityManager.IsAuthenticated(sourceUserID, sourceUserPassword))
                throw new ArgumentException($"Invalid source user or password: {sourceUserID}");
            if (!identityManager.IsValid(targetUserID))
                throw new ArgumentException($"Invalid target user: {targetUserID}");
            var r = new Response()
            {
                SourceUserID = sourceUserID,
                TargetUserID = targetUserID,
                Score = score,
                Comment = comment
            };

            question.AddResponse(r);
            this.context.SaveChanges();
        }

        public IEnumerable<Response> GetUsefulnesses(string userID, string password)
        {
            return this.context.Question.SelectMany(q => q.GetResponses())
                .Where(r => r.SourceUserID == userID && r.Usefulness != null).OfType<Response>();
        }
    }
}
