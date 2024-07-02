using AdoptionAgency.Backend.Domain.Model.Person;

namespace AdoptionAgency.Backend.Domain.RepositoryInterfaces
{
    public interface IPersonRepository : ICrudRepository<Person>
    {
        public List<Person> GetVolunteers();
        public List<Person> GetMembers();
        public List<Person> GetAdministrators();
    }
}
