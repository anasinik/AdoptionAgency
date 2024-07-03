using AdoptionAgency.Backend.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class RegisterMemberViewModel : ViewModelBase
    {
        public string FirstName
        {
            get => FirstName;
            set
            {
                FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => LastName;
            set
            {
                LastName = value;
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

        public string PhoneNumber
        {
            get => PhoneNumber;
            set
            {
                PhoneNumber = value;
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

        public string Password
        {
            get => Password;
            set
            {
                Password = value;
                OnPropertyChanged();
            }
        }

        public RegisterMemberViewModel()
        {

        }
    }
}
