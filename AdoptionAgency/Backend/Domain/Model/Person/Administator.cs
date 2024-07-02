namespace AdoptionAgency.Backend.Domain.Model.Person
{
    public class Administator : Person
    {
        public Administator(int id, int userId, string name, string lastName, string email, string phoneNumber)
            : base(id, userId, name, lastName, email, phoneNumber)
        {

        }
    }
}
