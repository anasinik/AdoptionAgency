using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        public MemberViewModel(Member member)
        {
            Id = member.Id;
            Username = member.User.Username;
            Password = member.User.Password;
            Name = member.Name;
            LastName = member.LastName;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
        }
        public MemberViewModel(int id, User user, string name, string lastName, string email, string phoneNumber)
        {
            Id = id;
            Username = user.Username;
            Password = user.Password;
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

