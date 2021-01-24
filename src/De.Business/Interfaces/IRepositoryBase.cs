using De.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace De.Business.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GeById(Guid id);
        Task<TEntity> GeById(string id);
        Task<TEntity> GeById(int id);

        Task Add(TEntity model);
        Task Update(TEntity model);

        Task Delete(TEntity model);
        Task Delete(Guid model);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
