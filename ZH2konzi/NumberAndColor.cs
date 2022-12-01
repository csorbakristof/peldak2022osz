using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ZH2konzi
{
    public class NumberAndColor : INotifyPropertyChanged
    {
        private readonly SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);

        private int number;
        private SolidColorBrush brush;
        public int Number
        { 
            get
            {
                return number;
            }
            set
            {
                if (number != value)
                {
                    number = value;
                    Brush = number < 50 ? greenBrush : redBrush;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
                }
            }
        }
        public SolidColorBrush Brush
        {
            get
            {
                return brush;
            }
            set
            {
                if (brush != value)
                {
                    brush = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brush)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
