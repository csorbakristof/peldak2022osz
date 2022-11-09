using Core;
using System;
using System.Collections.Generic;
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
    public sealed partial class AddResponse : Page
    {

        private App app;

        public AddResponse()
        {
            this.InitializeComponent();
            app = Application.Current as App;
        }

        public Response ResponseToAdd = new Response() { SourceUserID = "OK8KLBY", TargetUserID = "OK8KLBY", Score = 3, Comment = "ABC" };
        public string RespondingUserPassword = "OISZH";

        private async void AddNewResponse(object sender, RoutedEventArgs e)
        {
            // Get selected question
            if (QuestionListBox.SelectedIndex < 0)
            {
                await new MessageDialog("Előbb válassz ki egy kérdést...").ShowAsync();
                return;
            }
            //await new MessageDialog($"Kiválasztott kérdés indexe: {QuestionListBox.SelectedIndex}").ShowAsync();
            if (!app.IdentityManager.IsAuthenticated(ResponseToAdd.SourceUserID, RespondingUserPassword))
            {
                await new MessageDialog("Érvénytelen értékelő UserID - jelszó páros...").ShowAsync();
                return;
            }
            if (!app.IdentityManager.IsValid(ResponseToAdd.TargetUserID))
            {
                await new MessageDialog("Érvénytelen cél UserID").ShowAsync();
                return;
            }
            app.Questions[QuestionListBox.SelectedIndex].Responses.Add(ResponseToAdd);

            this.Frame.GoBack();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
