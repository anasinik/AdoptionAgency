
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.PostRepositories
{
    public class PictureRepository : ICrudRepository<Picture>
    {
        private readonly DatabaseContext _context;

        public PictureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public int Add(Picture picture)
        {
            _context.Picture.Add(picture);
            _context.SaveChanges();
            return picture.Id;
        }

        public void Delete(int id)
        {
            var existing = _context.Picture.Find(id);
            if (existing == null) return;

            _context.Picture.Remove(existing);
            _context.SaveChanges();
        }

        public Picture Get(int id)
        {
            return _context.Picture.Find(id);
        }

        public List<Picture> GetAll()
        {
            return _context.Picture.ToList();
        }

        public void Update(Picture picture)
        {
            var existing = _context.Picture.Find(picture.Id);
            if (existing != null)
                _context.Entry(existing).State = EntityState.Detached;

            _context.Picture.Update(picture);
            _context.SaveChanges();
        }
    }
}
