using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.AnimalRepositories
{
    public class AnimalRepository : ICrudRepository<Animal>
    {
        private readonly DatabaseContext _context;

        public AnimalRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Animal Add(Animal animal)
        {
            _context.Animal.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public void Delete(int id)
        {
            var existing = _context.Animal.Find(id);
            if (existing == null) return;

            _context.Animal.Remove(existing);
            _context.SaveChanges();
        }

        public Animal Get(int id)
        {
            return _context.Animal
                .Include(a => a.Species)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Animal> GetAll()
        {
            return _context.Animal.Include(a => a.Species).ToList();
        }

        public void Update(Animal animal)
        {
            var existing = _context.Animal.Find(animal.Id);
            if (existing != null)
                _context.Entry(existing).State = EntityState.Detached;
            
            _context.Animal.Update(animal);
            _context.SaveChanges();

        }
    }
}
