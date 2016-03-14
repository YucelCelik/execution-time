using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Papyrus.Domain.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T data);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }
}
