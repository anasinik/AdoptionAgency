using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services
{
    public class PersonService
    {

        private readonly IPersonRepository _repository;

        public PersonService()
        {
            _repository = ServiceProviderHelper.GetService<IPersonRepository>();   
        }

        public Person Add(Person person)
        {
            return _repository.Add(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Person? Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Person> GetMembers()
        {
            return _repository.GetMembers();
        }

        public List<Person> GetVolunteers()
        {
            return _repository.GetVolunteers();
        }

        public List<Person> GetAdministrators()
        {
            return _repository.GetAdministrators();
        }

        public void Update(Person person)
        {
            _repository.Update(person);
        }

    }
}
