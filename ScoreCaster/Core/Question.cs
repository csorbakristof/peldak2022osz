using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int MinResponseLength { get; set; }

        public ObservableCollection<Response> Responses = new ObservableCollection<Response>();

        public void AddResponse(Response response)
        {
            Responses.Add(response);
        }

    }
}
