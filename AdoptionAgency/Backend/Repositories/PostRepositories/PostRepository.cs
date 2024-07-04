using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories.PostRepositories
{
    public class PostRepository : ICrudRepository<Post>
    {
        private readonly DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Post Add(Post post)
        {
            _context.Post.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Delete(int id)
        {
            var existing = _context.Post.Find(id);
            if (existing == null) return;

            _context.Post.Remove(existing);
            _context.SaveChanges();
        }

        public Post Get(int id)
        {
            return _context.Post.Find(id);
        }

        public List<Post> GetAll()
        {
            return _context.Post.Include(p => p.Animal)
                                .Include(p => p.Person)
                                .Include(p => p.Pictures)
                                .ToList();
        }

        public void Update(Post post)
        {
            var existing = _context.Post.Find(post.Id);
            if (existing != null)
                _context.Entry(existing).State = EntityState.Detached;

            _context.Post.Update(post);
            _context.SaveChanges();
        }
    }
}
