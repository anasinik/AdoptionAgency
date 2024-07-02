using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;

namespace AdoptionAgency.Backend.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public int Add(Person person)
        {
            _context.Person.Add(person);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = _context.Person.Find(id);
            if (person != null)
                _context.Person.Remove(person);
        }

        public Person? Get(int id)
        {
            return _context.Person.Find(id);
        }

        public List<Person> GetAll()
        {
            return _context.Person.ToList();
        }

        public List<Person> GetMembers()
        {
            return _context.Person.Where(person => person.User.Type == UserType.Member).ToList();
        }

        public List<Person> GetVolunteers()
        {
            return _context.Person.Where(person => person.User.Type == UserType.Volunteer).ToList();
        }

        public List<Person> GetAdministrators()
        {
            return _context.Person.Where(person => person.User.Type == UserType.Administator).ToList();
        }

        public void Update(Person person)
        {
            _context.Person.Update(person);
            _context.SaveChanges();
        }

    }
}
