using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Frontend.View.AdminView;
using AdoptionAgency.Frontend.View.Authentication;
using AdoptionAgency.Frontend.View.Member;
using AdoptionAgency.Frontend.View.VolunteerView;
using System.ComponentModel;
using System.Security.Authentication;

namespace AdoptionAgency.Frontend.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _username = "";
        private string _password = "";

        public string Username
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
        

        public MainWindowViewModel() { }
        public bool Login()
        {
            return TrySignUp(Username, Password);
        }

        private bool TrySignUp(string email, string password)
        {
            try
            {
                var loginService = new LoginService();
                User user = loginService.GetByCredentials(email, password).User;
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
            var registrationWindow = new RegisterView();
            registrationWindow.Show();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
