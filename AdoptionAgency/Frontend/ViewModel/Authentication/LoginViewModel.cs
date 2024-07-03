using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Frontend.View.AdminView;
using AdoptionAgency.Frontend.View.Member;
using AdoptionAgency.Frontend.View.VolunteerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AdoptionAgency.Frontend.View.Authentication;
using System.ComponentModel;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = "";
        private string _password = "";

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
        public LoginViewModel()
        {

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
