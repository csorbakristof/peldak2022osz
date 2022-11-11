using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarReminder
{
    internal abstract class ConfigLoaderBase
    {
        public abstract IEnumerable<ConfigEntry> Load();

        public static ConfigLoaderBase CreateLoader(string filename)
        {
            if (filename.EndsWith(".csv"))
                // Van értelme visszaadni és nem meghívni a Load-ját?
                return new ConfigLoaderCsv(filename);
            else
                throw new NotSupportedException("Unknown configration format.");
        }
    }
}
