using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.AnimalServices
{
    public class AdoptionRequestService
    {
        private readonly IAdoptionRequestRepository _repository;

        public AdoptionRequestService()
        {
            _repository = ServiceProviderHelper.GetService<IAdoptionRequestRepository>();
        }

        public AdoptionRequest Add(AdoptionRequest adoptionRequest)
        {
            return _repository.Add(adoptionRequest);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public AdoptionRequest Get(int id)
        {
            return _repository.Get(id);
        }

        public List<AdoptionRequest> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(AdoptionRequest adoptionRequest)
        {
            _repository.Update(adoptionRequest);
        }

        public bool Exists(Animal animal, Person person)
        {
            return _repository.Exists(animal, person);
        }
    }
}
