﻿namespace AdoptionAgency.Backend.Domain.RepositoryInterfaces
{
    public interface ICrudRepository<T>
    {
        public T Get(int id);
        public List<T> GetAll();
        public T Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
