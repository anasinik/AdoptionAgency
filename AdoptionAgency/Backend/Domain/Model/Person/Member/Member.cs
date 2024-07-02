namespace AdoptionAgency.Backend.Domain.Model.Person.Member
{
    public class Member : Person
    {
        public Member(int id, int userId, string name, string lastName, string email, string phoneNumber) 
            : base(id, userId, name, lastName, email, phoneNumber)
        {
            
        }
    }
}
