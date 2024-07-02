
using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.AnimalRepositories
{
    public class AnimalSpeciesRepository : ICrudRepository<AnimalSpecies>
    {
        private readonly DatabaseContext _context;
        public AnimalSpeciesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public int Add(AnimalSpecies animalSpecies)
        {
            var existingAnimalSpecies = GetExistingSpecies(animalSpecies.Species, animalSpecies.Breed);
            if (existingAnimalSpecies != null)
            {
                return existingAnimalSpecies.Id;
            }
            return AddNewAnimalSpecies(animalSpecies);
        }

        private int AddNewAnimalSpecies(AnimalSpecies animalSpecies)
        {
            _context.AnimalSpecies.Add(animalSpecies); 
            _context.SaveChanges();
            return animalSpecies.Id;
        }

        private AnimalSpecies? GetExistingSpecies(string species, string breed)
        {
            return _context.AnimalSpecies
                .FirstOrDefault(animalSpecies => animalSpecies.Species.ToLower() == species.ToLower() && animalSpecies.Breed == breed);
        }

        public void Delete(int id)
        {
            var existing = _context.AnimalSpecies.Find(id);
            if (existing == null) return;

            _context.AnimalSpecies.Remove(existing);
        }

        public AnimalSpecies Get(int id)
        {
            return _context.AnimalSpecies.Find(id);
        }

        public List<AnimalSpecies> GetAll()
        {
            return _context.AnimalSpecies.ToList();
        }

        public void Update(AnimalSpecies animalSpecies)
        {
            var existing = _context.AnimalSpecies.Find(animalSpecies.Id);
            if (existing != null)
                _context.Entry(existing).State = EntityState.Detached;

            _context.AnimalSpecies.Update(animalSpecies);
            _context.SaveChanges();
        }
    }
}
