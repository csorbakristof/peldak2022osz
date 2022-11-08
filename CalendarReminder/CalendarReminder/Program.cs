using System.Globalization;

var csv = File.ReadAllText(@"..\..\..\config.csv");
var rows = csv.Split('\n');

using StreamWriter output = new("..\\..\\..\\output.ical");
output.WriteLine(@"BEGIN: VCALENDAR");
output.WriteLine(@"VERSION:2.0");
output.WriteLine(@"CALSCALE:GREGORIAN");
output.WriteLine(@"METHOD:PUBLISH");

DateOnly week0StartDate = new DateOnly(2022, 08, 29);

foreach (var entry in rows)
{
    var fields = entry.Split(';');
    if (fields.Length < 2)
        continue;
    var weekIndex = int.Parse(fields[0]);
    var message = fields[1].Trim();
    Console.WriteLine($"({weekIndex})-({message})");

    // https://icalendar.org/
    // https://icalendar.org/iCalendar-RFC-5545/4-icalendar-object-examples.html
    var currentDate = week0StartDate.AddDays(7 * weekIndex);
    output.WriteLine(@"BEGIN:VEVENT");
    output.WriteLine(@"SUMMARY: Event summary");
    output.WriteLine($"DTSTART: {currentDate.Year:D2}{currentDate.Month:D2}{currentDate.Day:D2}T080000");
    output.WriteLine($"DTEND: {currentDate.Year:D2}{currentDate.Month:D2}{currentDate.Day:D2}T083000");
    output.WriteLine($"DESCRIPTION: {message}");
    output.WriteLine(@"END:VEVENT");
}

output.WriteLine(@"END:VCALENDAR");