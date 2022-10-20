using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class ReviewerServices
    {
        private QuestionsContainer questions;
        private IIdentityManager identityManager;

        public ReviewerServices(QuestionsContainer questionsContainer,
            IIdentityManager identityManager)
        {
            this.questions = questionsContainer;
            this.identityManager = identityManager;
        }

        public IEnumerable<Question> GetQuestions()
        {
            return questions.Questions;
        }

        public void AddFeedback(string sourceUserID, string sourceUserPassword,
            string targetUserID, int questionID, int score, string comment)
        {
            var question = this.questions.Questions.Single(q => q.ID == questionID);
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
            throw new NotImplementedException();
        }
    }
}
