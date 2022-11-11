using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarReminder
{
    internal class IcalExportVisitor : ICalendarEntryVisitor
    {
        private StreamWriter output;

        public IcalExportVisitor(StreamWriter output)
        {
            this.output = output;
        }

        public void Visit(CalendarEntry entry)
        {
            output.Write(ToIcalString(entry));
        }

        private string ToIcalString(CalendarEntry entry)
        {
            StringBuilder sb = new();
            // https://icalendar.org/
            // https://icalendar.org/iCalendar-RFC-5545/4-icalendar-object-examples.html
            sb.AppendLine(@"BEGIN:VEVENT");
            sb.AppendLine(@"SUMMARY: Event summary");
            sb.AppendLine($"DTSTART: {ToIcalDatetimeString(entry.Start)}");
            sb.AppendLine($"DTEND: {ToIcalDatetimeString(entry.End)}");
            sb.AppendLine($"DESCRIPTION: {entry.Summary}");
            sb.AppendLine(@"END:VEVENT");
            return sb.ToString();
        }

        private static string ToIcalDatetimeString(DateTime datetime)
        {
            return $"{datetime.Year:D2}{datetime.Month:D2}{datetime.Day:D2}T{datetime.Hour:D2}{datetime.Minute:D2}00";
        }

        public void WriteHeader()
        {
            output.WriteLine(@"BEGIN: VCALENDAR");
            output.WriteLine(@"VERSION:2.0");
            output.WriteLine(@"CALSCALE:GREGORIAN");
            output.WriteLine(@"METHOD:PUBLISH");
        }

        public void WriteTail()
        {
            output.WriteLine(@"END:VCALENDAR");
        }


    }
}
