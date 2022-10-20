namespace Common
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int MinResponseLength { get; set; }

        private List<Response> responses = new List<Response>();

        internal void AddResponse(Response response)
        {
            responses.Add(response);
        }
    }
}
