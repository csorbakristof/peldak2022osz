using System.Collections.Generic;

namespace Core
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int MinResponseLength { get; set; }

        public List<Response> Responses = new List<Response>();

        public void AddResponse(Response response)
        {
            Responses.Add(response);
        }

        public IEnumerable<Response> GetResponses()
        {
            return Responses;
        }
    }
}
