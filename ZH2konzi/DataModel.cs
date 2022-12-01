using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2konzi
{
    public class DataModel : INotifyPropertyChanged
    {
        public ObservableCollection<NumberAndColor> List;

        private NumberAndColor selectedItem;
        public NumberAndColor SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
        }

        public DataModel()
        {
            List = new ObservableCollection<NumberAndColor>();
            List.Add(new NumberAndColor() { Number = 20 });
            List.Add(new NumberAndColor() { Number = 40 });
            List.Add(new NumberAndColor() { Number = 60 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
