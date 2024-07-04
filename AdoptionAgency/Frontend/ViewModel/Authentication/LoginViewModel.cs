using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Frontend.View.AdminView;
using AdoptionAgency.Frontend.View.Authentication;
using AdoptionAgency.Frontend.View.UserViews;
using System.Security.Authentication;
using System.Windows;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private MainWindow _mainWindow;

        public LoginViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public bool Login()
        {
            try
            {
                var loginService = new LoginService();
                App.LoggedIn = loginService.GetByCredentials(Username, Password);
                if (App.LoggedIn.User.Status != Status.Accepted)
                {
                    MessageBox.Show("Your registration request is not accepted yet.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                OpenAppropriateWindow(App.LoggedIn.User);
                return true;
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return false;
        }


        private void OpenAppropriateWindow(User user)
        {
            if (user.Type == UserType.Member)
            {
                MemberView memberView = new();
                memberView.Show();
            }
            else if (user.Type == UserType.Volunteer)
            {
                VolunteerView volunteerView = new();
                volunteerView.Show();
            }
            else if (user.Type == UserType.Administator)
            {
                AdminView administatorView = new();
                administatorView.Show();
            }
        }
        public void ShowRegistrationWindow()
        {
            var registrationWindow = new RegisterView(_mainWindow);
            registrationWindow.Show();
        }

    }
}
