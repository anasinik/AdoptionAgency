using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.AnimalRepositories
{
    public class AnimalRatingRepository : ICrudRepository<AnimalRating>
    {
        private readonly DatabaseContext _context;
        public AnimalRatingRepository(DatabaseContext context)
        {
            _context = context;
        } 

        public AnimalRating Add(AnimalRating animalRating)
        {
            _context.AnimalRating.Add(animalRating);
            _context.SaveChanges();
            return animalRating;
        }

        public void Delete(int id)
        {
            var existing = _context.AnimalRating.Find(id);
            if (existing == null) return;

            _context.AnimalRating.Remove(existing);
            _context.SaveChanges();
        }

        public AnimalRating Get(int id)
        {
            return _context.AnimalRating.Find(id);
        }

        public List<AnimalRating> GetAll()
        {
            return _context.AnimalRating.ToList();  
        }

        public void Update(AnimalRating animalRating)
        {
            var existing = _context.AnimalRating.Find(animalRating.Id);
            if (existing != null)
                _context.Entry(existing).State = EntityState.Detached;
            
            _context.AnimalRating.Update(animalRating);
            _context.SaveChanges();
        }
    }
}
