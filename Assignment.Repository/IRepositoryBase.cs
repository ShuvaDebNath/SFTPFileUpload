using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        int SaveChange();
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}
