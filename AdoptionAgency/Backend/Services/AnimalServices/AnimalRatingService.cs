using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.AnimalServices
{
    public class AnimalRatingService
    {
        private readonly ICrudRepository<AnimalRating> _repository;

        public AnimalRatingService()
        {
            _repository = ServiceProviderHelper.GetService<ICrudRepository<AnimalRating>>();
        }

        public int Add(AnimalRating animalRating)
        {
            return _repository.Add(animalRating);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public AnimalRating Get(int id)
        {
            return _repository.Get(id);
        }

        public List<AnimalRating> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(AnimalRating animalRating)
        {
            _repository.Update(animalRating);
        }

    }
}
