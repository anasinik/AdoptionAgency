using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.MemberViewModels;
using System.Windows;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class RegisterViewModel : ViewModelBase
    {
        public string Username
        {
            get => Username;
            set
            {
                Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => Password;
            set
            {
                Password = value;
                OnPropertyChanged();
            }
        }
        public string Firstname
        {
            get => Firstname;
            set
            {
                Firstname = value;
                OnPropertyChanged();
            }
        }
        public string Lastname
        {
            get => Lastname;
            set
            {
                Lastname = value;
                OnPropertyChanged();
            }
        }
        public Gender Gender
        {
            get => Gender;
            set
            {
                Gender = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => Email;
            set
            {
                Email = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => PhoneNumber;
            set
            {
                PhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public RegisterViewModel()
        {
            
        }
        public bool SignUp()
        {
            var personService = new PersonService();
            var user = new User(Username, Password, Backend.Domain.Model.Common.Status.Pending);
            var member = new Member(user, Firstname, Lastname, Email, PhoneNumber);
            personService.Add(member);
            MessageBox.Show("Success!");
            return true;
        }
    }
}
