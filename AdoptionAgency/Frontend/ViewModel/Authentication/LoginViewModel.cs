using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Frontend.View.AdminView;
using AdoptionAgency.Frontend.View.Authentication;
using AdoptionAgency.Frontend.View.UserViews;
using AdoptionAgency.Frontend.View.VolunteerView;
using System.ComponentModel;
using System.Security.Authentication;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = "";
        private string _password = "";
        private MainWindow _mainWindow;

        public string UserName
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public LoginViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public bool Login()
        {
            return TrySignUp(UserName, Password);
        }

        private bool TrySignUp(string username, string password)
        {
            try
            {
                var loginService = new LoginService();
                User user = loginService.GetByCredentials(username, password).User;
                OpenAppropriateWindow(user);
                return true;
            }
            catch (AuthenticationException ex)
            {
                return false;
            }
        }
        private void OpenAppropriateWindow(User user)
        {
            if (user.GetType() == typeof(Member))
            {
                MemberView memberView = new();
                memberView.Show();
            }
            else if (user.GetType() == typeof(Volunteer))
            {
                VolunteerView volunteerView = new();
                volunteerView.Show();
            }
            else if (user.GetType() == typeof(Administator))
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


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
