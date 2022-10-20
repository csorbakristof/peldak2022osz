using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Response
    {
        public int Score { get; set; }
        public string Comment { get; set; }

        public string SourceUserID { get; set; }
        public string TargetUserID { get; set; }

        public Response Usefulness { get; set; }
    }
}
