using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.AnimalRepositories
{
    public class AdoptionRequestRepository : ICrudRepository<AdoptionRequest>
    {
        private readonly DatabaseContext _context;

        public AdoptionRequestRepository(DatabaseContext context)
        {
            _context = context;
        }

        public AdoptionRequest Add(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequest.Add(adoptionRequest);
            _context.SaveChanges();
            return adoptionRequest;
        }

        public void Delete(int id)
        {
            var existing = _context.AdoptionRequest.Find(id);
            if (existing == null) return;
            
            _context.AdoptionRequest.Remove(existing);
            _context.SaveChanges();
        }

        public AdoptionRequest Get(int id)
        {
            return _context.AdoptionRequest.Find(id);
        }

        public List<AdoptionRequest> GetAll()
        {
            return _context.AdoptionRequest.ToList();
        }

        public void Update(AdoptionRequest adoptionRequest)
        {
            var exising = _context.AdoptionRequest.Find(adoptionRequest.Id);
            if (exising != null)
                _context.Entry(exising).State = EntityState.Detached;

            _context.AdoptionRequest.Update(exising);
            _context.SaveChanges();
        }
    }
}
