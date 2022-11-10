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
    public sealed partial class ViewResponses : Page, INotifyPropertyChanged
    {
        private App app;
        public ViewResponses()
        {
            this.InitializeComponent();
            app = Application.Current as App;
        }

        private string userID;

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            userID = e.Parameter as string;
            base.OnNavigatedTo(e);
        }

        private IEnumerable<Response> ResponsesForUserOnSelectedQuestion
            => QuestionListBox.SelectedIndex >= 0
            ? app.Questions[QuestionListBox.SelectedIndex]
                .Responses.Where(r => r.TargetUserID == userID)
            : null;

        private void QuestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(ResponsesForUserOnSelectedQuestion)));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void Usefulness(object sender, RoutedEventArgs e)
        {
            var avg = app.Questions.SelectMany(q => q.Responses)
                .Select(r => r.Usefulness.Score).Where(s => s > 0).Average();
            await (new MessageDialog($"Átlagos hasznosság: {avg}")).ShowAsync();
        }
    }
}
