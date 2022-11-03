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

        private void AddTestData(object sender, RoutedEventArgs e)
        {
            Questions.Add(new Question() { ID = 1, Text = "Első kérdés", MinResponseLength = 0 });
            Questions.Add(new Question() { ID = 2, Text = "Második kérdés", MinResponseLength = 0 });
            Questions.Add(new Question() { ID = 3, Text = "Harmadik kérdés", MinResponseLength = 0 });
        }

        private void GenerateNewUserIdAndPassword(object sender, RoutedEventArgs e)
        {
            (string userId, string password) = this.generalServices.GenerateUserID(this.NeptunCode.Text);
            this.NewUserID.Text = userId;
            this.NewPassword.Text = password;
        }

        public Response NewResponse { get; set; } = new Response();
        public string Password { get; set; }

        private async void AddResponse(object sender, RoutedEventArgs e)
        {
            if (QuestionSelector.SelectedIndex == -1)
            {
                await (new MessageDialog("Nincs kérdés kiválasztva... :( Nemmety..."))
                    .ShowAsync();
                return;
            }

            if (!identityManager.IsAuthenticated(NewResponse.SourceUserID, Password))
            {
                await (new MessageDialog("Hibás értékelő user adatok...")).ShowAsync();
                return;
            }

            if (!identityManager.IsValid(NewResponse.TargetUserID))
            {
                await (new MessageDialog("Hibás értékelt user adatok...")).ShowAsync();
                return;
            }

            Questions[QuestionSelector.SelectedIndex].AddResponse(NewResponse);

        }
    }
}
