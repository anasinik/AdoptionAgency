using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.AnimalServices
{
    public class AnimalService
    {
        private readonly ICrudRepository<Animal> _repository;

        public AnimalService()
        {
            _repository = ServiceProviderHelper.GetService<ICrudRepository<Animal>>();
        }

        public int Add(Animal animal)
        {
            return _repository.Add(animal);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Animal Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Animal> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Animal animal)
        {
            _repository.Update(animal);
        }

    }
}
