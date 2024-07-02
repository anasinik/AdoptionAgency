namespace AdoptionAgency.Backend.Domain.Model.Person
{
    public class Volunteer : Person
    {
        public Volunteer(int id, User.User user, string name, string lastName, string email, string phoneNumber)
            : base(id, user, name, lastName, email, phoneNumber) { }
    }
}
