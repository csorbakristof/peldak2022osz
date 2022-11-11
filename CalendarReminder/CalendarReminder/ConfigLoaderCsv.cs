namespace CalendarReminder
{
    internal class ConfigLoaderCsv : ConfigLoaderBase
    {
        private string filename;

        public ConfigLoaderCsv(string filename)
        {
            this.filename = filename;
        }

        public override IEnumerable<ConfigEntry> Load()
        {
            var csv = File.ReadAllText(filename);
            var rows = csv.Split('\n');
            foreach(var row in rows)
            {
                var fields = row.Split(';');
                if (fields.Length < 2)
                    continue;
                var weekIndex = int.Parse(fields[0]);
                var message = fields[1].Trim();
                var newEntry = new ConfigEntry()
                {
                    WeekIndex = weekIndex,
                    Message = message
                };
                yield return newEntry;
            }
        }
    }
}
