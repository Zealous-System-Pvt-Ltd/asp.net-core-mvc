using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MPD.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly MPDContext _dbContext;
        private readonly DbSet<T> _entities;

        public RepositoryBase(MPDContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _entities.SingleOrDefault(filter);
        }

        public T GetById(object id)
        {
            return _entities.Find(id);
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            return _entities.Count(filter);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _entities.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            //return SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            //SaveChanges();

        }

        public void Remove(object id)
        {
            T entity = _entities.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("id");
            }
            Remove(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            //SaveChanges();
        }

        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
