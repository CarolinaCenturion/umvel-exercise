using Microsoft.EntityFrameworkCore;
using Sales.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<TEntity> _entity;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public DbSet<TEntity> Entity
        {
            get
            {
                if (_entity == null)
                    _entity = _context.Set<TEntity>();
                return _entity;
            }
        }

        #region Synchronous Methods
        public virtual IQueryable<TEntity> GetAll() => _entity.AsNoTracking();

        public virtual IQueryable<TEntity> GetByColumn(Expression<Func<TEntity, bool>> expression)
            => _entity.AsNoTracking().Where(expression);

        public virtual TEntity GetOneByColumn(Expression<Func<TEntity, bool>> expression)
            => _entity.AsNoTracking().Where(expression).FirstOrDefault();

        public virtual TEntity GetById(object id) => _entity.Find(id);

        public virtual TEntity Create(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var created = _entity.Add(entity);
                if (saveChanges) _context.SaveChanges();
                return created.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual TEntity Update(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var entry = _context.Entry(entity);
                _entity.Attach(entity);
                entry.State = EntityState.Modified;
                if (saveChanges) _context.SaveChanges();
                return entry.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual TEntity Delete(object id, bool saveChanges = false)
        {
            try
            {
                TEntity entity = _entity.Find(id);
                if (entity != null)
                {
                    _entity.Remove(entity);
                    if (saveChanges) _context.SaveChanges();
                    return entity;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual TEntity Delete(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var deleted = _entity.Attach(entity);
                _entity.Remove(entity);
                if (saveChanges) _context.SaveChanges();
                return deleted.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression, bool saveChanges = false)
        {
            try
            {
                var current = _entity.Where(expression).ToList();
                _entity.RemoveRange(current);
                if (saveChanges) _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression) => _entity.Where(expression).Count();

        public virtual bool Exist(Expression<Func<TEntity, bool>> expression) => _entity.Where(expression).Any();

        #endregion

        #region Asynchronous Methods
        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var list = await _entity.ToListAsync();
            return list.AsQueryable().AsNoTracking();
        }
        public virtual async Task<IQueryable<TEntity>> GetByColumnAsync(Expression<Func<TEntity, bool>> expression)
        {
            var list = await _entity.Where(expression).ToListAsync();
            return list.AsQueryable().AsNoTracking();
        }

        public virtual async Task<TEntity> GetOneByColumnAsync(Expression<Func<TEntity, bool>> expression)
            => await _entity.Where(expression).FirstOrDefaultAsync();

        public virtual async Task<TEntity> GetByIdAsync(object id) => await _entity.FindAsync(id);

        public virtual async Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var created = await _entity.AddAsync(entity);
                if (saveChanges) await _context.SaveChangesAsync();
                return created.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var entry = _context.Entry(entity);
                _entity.Attach(entity);
                entry.State = EntityState.Modified;
                if (saveChanges) await _context.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<TEntity> DeleteAsync(object id, bool saveChanges = false)
        {
            try
            {
                var current = await _entity.FindAsync(id);
                if (current != null)
                {
                    var entry = _context.Attach(current);
                    entry.State = EntityState.Deleted;
                    _entity.Remove(current);
                    if (saveChanges) await _context.SaveChangesAsync();
                    return entry.Entity;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> expression, bool saveChanges = false)
        {
            try
            {
                var current = await _entity.Where(expression).ToListAsync();
                _entity.RemoveRange(current);
                if (saveChanges) await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            try
            {
                var entry = _entity.Attach(entity);
                _entity.Remove(entity);
                if (saveChanges) await _context.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
            => await _entity.Where(expression).CountAsync();

        public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
            => await _entity.Where(expression).AnyAsync();
        #endregion
    }

}
