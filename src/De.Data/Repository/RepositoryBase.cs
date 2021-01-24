using De.Business.Interfaces;
using De.Business.Models;
using De.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace De.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly EfContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected RepositoryBase(EfContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GeById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GeById(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GeById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity model)
        {
            DbSet.Add(model);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity model)
        {
            DbSet.Update(model);
            await SaveChanges();
        }
        public virtual async Task Delete(TEntity model)
        {
            DbSet.Remove(model);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid model)
        {
            DbSet.Remove(new TEntity { Id = model });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
            //o ? se existir faz dispose se não não, isso evitta null exception
        }
    }
}
