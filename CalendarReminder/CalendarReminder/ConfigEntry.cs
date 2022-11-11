namespace CalendarReminder
{
    internal class ConfigEntry
    {
        public int WeekIndex { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return $"({WeekIndex})-({Message})";
        }
    }
}