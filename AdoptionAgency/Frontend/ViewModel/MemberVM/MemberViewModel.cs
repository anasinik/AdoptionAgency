using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AdoptionAgency.Frontend.ViewModel.MemberVM
{
    public class MemberViewModel : ViewModelBase
    {
        public int Id 
        {
            get => Id;
            set
            {
                Id = value; 
                OnPropertyChanged();
            } 
        }
        public User User 
        {
            get => User;
            set
            {
                User = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => Name;
            set
            {
                Name = value;
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

        public MemberViewModel() { }
        public MemberViewModel(int id, User user, string name, string lastName, string email, string phoneNumber)
        {
            Id = id;
            User = user;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Member ToMember()
        {
            return new Member(Id, User, Name, LastName, Email, PhoneNumber);
        }
    }
}

