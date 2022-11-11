using CalendarReminder;
using System.Text;

internal class CalendarEntry
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string? Summary { get; set; }
    public string? Comment { get; set; }

    private static readonly TimeOnly time0800 = new TimeOnly(8, 0);
    private static readonly TimeOnly time0830 = new TimeOnly(8, 30);
    // TODO: should create factory, CalendarEntry should not know about week0Monday...
    public CalendarEntry(ConfigEntry e, DateOnly week0Monday)
    {
        var date = week0Monday.AddDays(e.WeekIndex * 7);
        this.Start = date.ToDateTime(time0800);
        this.End = date.ToDateTime(time0830);
        this.Summary = e.Message;
    }

    internal void AcceptVisitor(ICalendarEntryVisitor visitor)
    {
        visitor.Visit(this);
    }
}
