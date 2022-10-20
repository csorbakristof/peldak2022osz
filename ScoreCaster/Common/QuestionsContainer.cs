using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
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
