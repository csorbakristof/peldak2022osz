using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommonTests
{
    public class ReviewerServices_GetUsefulnessesTests
    {
        private readonly ObservableCollection<Question> container = new ObservableCollection<Question>();
        private readonly DummyIdentityManager identityManager = new DummyIdentityManager();
        private readonly ReviewerServices service;

        const int questionID = 1;
        const int score = 1;

        const int usefulnessScore1 = 2;
        const int usefulnessScore2 = 5;

        public ReviewerServices_GetUsefulnessesTests()
        {
            service = new ReviewerServices(container, identityManager);
            var q = new Question() { ID = questionID, MinResponseLength = 0, Text = String.Empty };
            container.Add(q);

            var r1 = new Response()
            {
                SourceUserID = DummyIdentityManager.UserID,
                TargetUserID = DummyIdentityManager.ValidUserID2,
                Score = score,
                Comment = String.Empty
            };

            var r2 = new Response()
            {
                SourceUserID = DummyIdentityManager.ValidUserID2,
                TargetUserID = DummyIdentityManager.UserID,
                Score = score,
                Comment = String.Empty
            };
            q.AddResponse(r1);
            q.AddResponse(r2);

            var usefulness1 = new Response()
            {
                SourceUserID = DummyIdentityManager.ValidUserID2,
                TargetUserID = DummyIdentityManager.UserID,
                Score = usefulnessScore1,
                Comment = String.Empty
            };
            var usefulness2 = new Response()
            {
                SourceUserID = DummyIdentityManager.UserID,
                TargetUserID = DummyIdentityManager.ValidUserID2,
                Score = usefulnessScore2,
                Comment = String.Empty
            };
            r1.Usefulness = usefulness1;
            r2.Usefulness = usefulness2;

            var responses = service.GetUsefulnesses(DummyIdentityManager.UserID, DummyIdentityManager.Password);
            Assert.Equal(usefulnessScore1, responses.Single().Usefulness?.Score);
        }
    }
}
