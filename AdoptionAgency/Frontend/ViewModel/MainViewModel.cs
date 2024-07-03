using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoptionAgency.Frontend.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _email = "";
        private string _password = "";

        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
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
            return TrySignUp(Email, Password);
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
                MemberViewModel memberViewModel = new(user);
                memberViewModel.Show();
            }
            else if (user.GetType() == typeof(Volunteer))
            {
                VolunteerViewModel tutorViewModel = new(user);
                tutorViewModel.Show();
            }
            else if (user.GetType() == typeof(Administator))
            {
                AdministatorViewModel administatorViewModel = new(user);
                administatorViewModel.Show();
            }
        }

        public void ShowRegistrationWindow()
        {
            var registrationWindow = new RegisterMemberViewModel();
            registrationWindow.Show();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
