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
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        private NeptunBasedIdentityManager identityManager;
        private GeneralServices generalServices;
        private ReviewerServices reviewerServices;
        private NeptunCodeValidator neptunCodeValidator;

        public MainPage()
        {
            this.InitializeComponent();
            this.neptunCodeValidator = new NeptunCodeValidator();
            this.identityManager = new NeptunBasedIdentityManager(neptunCodeValidator);
            this.generalServices = new GeneralServices(identityManager);
            this.reviewerServices = new ReviewerServices(Questions, identityManager);
        }

        public Response ResponseToAdd = new Response() { SourceUserID = "OK8KLBY", TargetUserID = "OK8KLBY", Score=3, Comment="ABC" };
        public string RespondingUserPassword = "OISZH";

        private void AddTestData(object sender, RoutedEventArgs e)
        {
            Questions.Add(new Question() { ID = 1, Text = "Első kérdés", MinResponseLength = 0 });
            Questions.Add(new Question() { ID = 2, Text = "Második kérdés", MinResponseLength = 0 });
            Questions.Add(new Question() { ID = 3, Text = "Harmadik kérdés", MinResponseLength = 0 });
        }

        private async void AddResponse(object sender, RoutedEventArgs e)
        {
            // Get selected question
            if (QuestionListBox.SelectedIndex < 0)
            {
                await new MessageDialog("Előbb válassz ki egy kérdést...").ShowAsync();
                return;
            }
            //await new MessageDialog($"Kiválasztott kérdés indexe: {QuestionListBox.SelectedIndex}").ShowAsync();
            if (!identityManager.IsAuthenticated(ResponseToAdd.SourceUserID, RespondingUserPassword))
            {
                await new MessageDialog("Érvénytelen értékelő UserID - jelszó páros...").ShowAsync();
                return;
            }
            if (!identityManager.IsValid(ResponseToAdd.TargetUserID))
            {
                await new MessageDialog("Érvénytelen cél UserID").ShowAsync();
                return;
            }
            Questions[QuestionListBox.SelectedIndex].Responses.Add(ResponseToAdd);
        }

        private void GenerateNewUserIdAndPassword(object sender, RoutedEventArgs e)
        {
            (string userId, string password) = this.generalServices.GenerateUserID(this.NeptunCode.Text);
            this.NewUserID.Text = userId;
            this.NewPassword.Text = password;
        }
    }
}
