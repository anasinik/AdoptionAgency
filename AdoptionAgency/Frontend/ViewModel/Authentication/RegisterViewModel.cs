using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services;
using System.Windows;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class RegisterViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public RegisterViewModel()
        {
            
        }
        public bool SignUp()
        {
            var personService = new PersonService();
            var user = new User(Username, Password, Backend.Domain.Model.Common.Status.Pending);
            var member = new Member(user, FirstName, LastName, Email, PhoneNumber);
            personService.Add(member);
            MessageBox.Show("Success!");
            return true;
        }
    }
}
