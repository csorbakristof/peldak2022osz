using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AdminGui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private App app;

        public MainPage()
        {
            this.InitializeComponent();
            app = Application.Current as App;
        }

        private void AddTestData(object sender, RoutedEventArgs e)
        {
            app.Questions.Add(new Question() { ID = 1, Text = "Első kérdés", MinResponseLength = 0 });
            app.Questions.Add(new Question() { ID = 2, Text = "Második kérdés", MinResponseLength = 0 });
            app.Questions.Add(new Question() { ID = 3, Text = "Harmadik kérdés", MinResponseLength = 0 });
        }

        private void GenerateNewUserIdAndPassword(object sender, RoutedEventArgs e)
        {
            (string userId, string password) = app.GeneralServices.GenerateUserID(this.NeptunCode.Text);
            this.NewUserID.Text = userId;
            this.NewPassword.Text = password;
        }

        private void AddResponse(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddResponse));
        }

        private string userID = "OK8KLBY";
        private string password = "OISZH";
        private async void ViewResponses(object sender, RoutedEventArgs e)
        {
            if (app.IdentityManager.IsAuthenticated(userID, password))
            {
                this.Frame.Navigate(typeof(ViewResponses), userID);
            }
            else
            {
                await (new MessageDialog("Érvénytelen userID/jelszó...")).ShowAsync();
            }
        }
    }
}
