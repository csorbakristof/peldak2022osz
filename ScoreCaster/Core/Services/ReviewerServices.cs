using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ReviewerServices
    {
        private ICollection<Question> questions;
        private IIdentityManager identityManager;

        public ReviewerServices(ICollection<Question> questionsContainer,
            IIdentityManager identityManager)
        {
            this.questions = questionsContainer;
            this.identityManager = identityManager;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return questions;
        }

        public void AddResponse(string sourceUserID, string sourceUserPassword,
            string targetUserID, int questionID, int score, string comment)
        {
            var question = this.questions.Single(q => q.ID == questionID);
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
        }

        public IEnumerable<Response> GetUsefulnesses(string userID, string password)
        {
            return questions.SelectMany(q => q.GetResponses())
                .Where(r => r.SourceUserID == userID && r.Usefulness != null).OfType<Response>();
        }
    }
}
