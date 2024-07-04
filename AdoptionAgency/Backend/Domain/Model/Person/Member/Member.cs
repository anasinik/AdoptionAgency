namespace AdoptionAgency.Backend.Domain.Model.Person.Member
{
    public class Member : Person
    {
        public Member(int id, User.User user, string name, string lastName, string email, string phoneNumber) 
            : base(id, user, name, lastName, email, phoneNumber) { }

        public Member(User.User user, string name, string lastName, string email, string phoneNumber)
            : base(user, name, lastName, email, phoneNumber) { }

        public Member() { }
    }
}
