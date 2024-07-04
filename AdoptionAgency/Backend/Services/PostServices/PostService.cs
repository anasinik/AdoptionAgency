using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.PostServices
{
    public class PostService
    {
        private readonly ICrudRepository<Post> _repository;

        public PostService()
        {
            _repository = ServiceProviderHelper.GetService<ICrudRepository<Post>>();
        }

        public Post Add(Post post)
        {
            return _repository.Add(post);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Post Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Post> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Post> GetAllPending()
        {
            return _repository.GetAll().Where(p => p.Status == Status.Pending).ToList();
        }

        public void Update(Post post)
        {
            _repository.Update(post);
        }

        internal List<Post> GetAccepted()
        {
            return _repository.GetAll().Where(p => p.Status == Status.Accepted).ToList();
        }
    }
}
