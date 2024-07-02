namespace AdoptionAgency.Domain.Model.Person
{
    public class Volunteer : Person
    {
        public Volunteer(int id, int userId, string name, string lastName, string email, string phoneNumber)
            : base(id, userId, name, lastName, email, phoneNumber)
        {

        }
    }
}
