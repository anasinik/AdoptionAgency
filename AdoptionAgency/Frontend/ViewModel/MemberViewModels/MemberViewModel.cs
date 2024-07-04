using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.User;

namespace AdoptionAgency.Frontend.ViewModel.MemberViewModels
{
    public class MemberViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public MemberViewModel() { }
        public MemberViewModel(Member member)
        {
            Id = member.Id;
            Username = member.User.Username;
            Password = member.User.Password;
            User = new User(Username, Password, Status.Pending);
            Name = member.Name;
            LastName = member.LastName;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
        }

        public MemberViewModel(Person member)
        {
            Id = member.Id;
            Username = member.User.Username;
            Password = member.User.Password;
            User = new User(Username, Password, Status.Pending);
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

