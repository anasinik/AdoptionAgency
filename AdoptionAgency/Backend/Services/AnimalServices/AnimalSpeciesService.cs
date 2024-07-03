using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.AnimalServices
{
    public class AnimalSpeciesService
    {
        private readonly ICrudRepository<AnimalSpecies> _repository;

        public AnimalSpeciesService()
        {
            _repository = ServiceProviderHelper.GetService<ICrudRepository<AnimalSpecies>>();
        }

        public int Add(AnimalSpecies animalSpecies)
        {
            return _repository.Add(animalSpecies);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public AnimalSpecies Get(int id)
        {
            return _repository.Get(id);
        }

        public List<AnimalSpecies> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(AnimalSpecies animalSpecies)
        {
            _repository.Update(animalSpecies);
        }
    }
}
