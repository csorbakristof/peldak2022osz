using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class QuestionsContainer
    {
        public List<Question> Questions { get; set; }

        public QuestionsContainer()
        {
            Questions = new List<Question>();
        }
    }
}
