using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Person;

namespace AdoptionAgency.Backend.Domain.RepositoryInterfaces
{
    public interface IAdoptionRequestRepository : ICrudRepository<AdoptionRequest>
    {
        public bool Exists(Animal animal, Person person);
    }
}
