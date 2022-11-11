using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarReminder
{
    internal interface ICalendarEntryVisitor
    {
        public void Visit(CalendarEntry entry);
    }
}
