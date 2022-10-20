namespace Common
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int MinResponseLength { get; set; }

        private List<Response> responses = new List<Response>();

        public void AddResponse(Response response)
        {
            responses.Add(response);
        }

        public IEnumerable<Response> GetResponses()
        {
            return responses;
        }
    }
}
