using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MPD.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T GetByFilter(Expression<Func<T, bool>> filter);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        int GetCount(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Remove(T entity);
        void Remove(object id);
        void Update(T entity);
    }
}
