using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZH2konzi
{
    public class ShowCurrentValueCommand : ICommand
    {
        private readonly DataModel dataModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => (this.dataModel.SelectedItem != null);

        public ShowCurrentValueCommand(DataModel dataModel)
        {
            this.dataModel = dataModel;
            this.dataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        private void DataModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
                this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public async void Execute(object parameter)
        {
            var value = this.dataModel.SelectedItem.Number;
            var dialog = new Windows.UI.Popups.MessageDialog($"Aktuális: {value}");
            await dialog.ShowAsync();
        }
    }
}
