using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminGui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewResponsesAndSetUsefulness : Page, INotifyPropertyChanged
    {
        private readonly App app;
        private string userID;

        // Note: readonly field, so only OneWay data binding is possible...
        IEnumerable<Response> ResponsesOnCurrentQuestion =>
            QuestionListBox.SelectedIndex>=0
            ? app.Questions[QuestionListBox.SelectedIndex].Responses.Where(r => r.TargetUserID == userID)
            : null;

        public ViewResponsesAndSetUsefulness()
        {
            this.InitializeComponent();
            app = Application.Current as App;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                userID = e.Parameter.ToString();
            }
            base.OnNavigatedTo(e);
        }

        private void QuestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make response list update itself as data source (ResponsesOnCurrentQuestion) has changed.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResponsesOnCurrentQuestion)));
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void ShowOwnUsefulness(object sender, RoutedEventArgs e)
        {
            var usefulnesses = app.Questions.SelectMany(q => q.Responses).Where(r => r.SourceUserID == userID).Select(r => r.Usefulness.Score).Where(s=>s>0).ToArray();
            var mean = usefulnesses.Average();
            var count = usefulnesses.Length;
            await (new MessageDialog($"Visszajelzéseid átlagos hasznossága {mean:N2}, összesen {count} hasznosság visszajelzéssel.")).ShowAsync();
        }
    }
}
