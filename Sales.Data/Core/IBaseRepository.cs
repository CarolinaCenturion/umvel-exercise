using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Synchronous Methods
        DbSet<TEntity> Entity { get; }
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByColumn(Expression<Func<TEntity, bool>> expression);
        TEntity GetOneByColumn(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(object id);
        TEntity Create(TEntity entity, bool saveChanges = false);
        TEntity Update(TEntity entity, bool saveChanges = false);
        TEntity Delete(object id, bool saveChanges);
        TEntity Delete(TEntity entity, bool saveChanges = false);
        void Delete(Expression<Func<TEntity, bool>> expression, bool saveChanges = false);
        int Count(Expression<Func<TEntity, bool>> expression);
        bool Exist(Expression<Func<TEntity, bool>> expression);
        #endregion

        #region Asynchronous Methods
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetByColumnAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetOneByColumnAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, bool saveChanges = false);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression);
        #endregion
    }
}
