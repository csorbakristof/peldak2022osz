using CalendarReminder;
using System.Globalization;

const string filename = @"..\..\..\config.csv";
var configEntries = ConfigLoaderBase.CreateLoader(filename).Load();

using StreamWriter output = new("..\\..\\..\\output.ical");
var export = new IcalExportVisitor(output);
// TODO: template method for export header, content (using visitor) and tail.
export.WriteHeader();

DateOnly week0StartDate = new DateOnly(2022, 08, 29);

foreach (var e in configEntries)
{
    Console.WriteLine(e);

    var newCalendarEntry = new CalendarEntry(e, week0StartDate);

    newCalendarEntry.AcceptVisitor(export);
}

export.WriteTail();