using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;

namespace AdoptionAgency.Backend.Services.PostServices
{
    public class PictureService
    {
        private readonly ICrudRepository<Picture> _repository;

        public PictureService()
        {
            _repository = ServiceProviderHelper.GetService<ICrudRepository<Picture>>();
        }

        public int Add(Picture picture)
        {
            return _repository.Add(picture);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Picture Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Picture> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Picture picture)
        {
            _repository.Update(picture);
        }

    }
}
