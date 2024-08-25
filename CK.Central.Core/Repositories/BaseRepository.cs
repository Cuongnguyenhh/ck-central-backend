using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.DataObjects.Entity;
using CK.Central.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using NodaTime;

namespace CK.Central.Core.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IUnitOfWork _uow;
        private readonly DbContextBase _dbMasterContext;
        private readonly DbContextBase _dbSlaveContext;

        public BaseRepository(IUnitOfWork context, DbContextBase dbMasterContext, DbContextBase dbSlaveContext)
        {
            this._dbMasterContext = dbMasterContext;
            this._dbSlaveContext = dbSlaveContext;
            _uow = context ?? throw new ArgumentNullException(nameof(context));
            Dispose(false);
        }

        public IUnitOfWork UOW => _uow;


        public async Task<List<TEntity>> GetAllSlave() => await this._dbSlaveContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity> FindByIdSlave(Guid id) => await this._dbSlaveContext.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> FindByParentIdSlave(Guid id) => await this._dbSlaveContext.Set<TEntity>().Where(x => x.PK_UUID == id).AsNoTracking().ToListAsync();

        public async Task<TEntity> FindByCodeSlave(string code) => await this._dbSlaveContext.Set<TEntity>().Where(x => x.Code == code).AsNoTracking().FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> FilterSlave(Expression<Func<TEntity, bool>> predicate) => await this._dbSlaveContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();

        public async Task<List<TEntity>> GetAll() => await this._dbMasterContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<List<TEntity>> GetAllActive() => await this._dbMasterContext.Set<TEntity>().AsNoTracking().Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();

        public async Task<TEntity> FindById(Guid id) => await this._dbMasterContext.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> FindByParentId(Guid id) => await this._dbMasterContext.Set<TEntity>().Where(x => x.PK_UUID == id).AsNoTracking().ToListAsync();

        public async Task<TEntity> FindByCode(string code) => await this._dbMasterContext.Set<TEntity>().Where(x => x.Code == code).AsNoTracking().FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate) => await this._dbMasterContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();

        public async Task<Guid> Insert(TEntity entity)
        {
            if (entity.PK_UUID == new Guid("00000000-0000-0000-0000-000000000000"))
                entity.PK_UUID = Guid.NewGuid();

            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.CreatedBy = entity.CreatedBy;
            entity.CreatedDatetime = DateTime.Now;

            await this._dbMasterContext.AddAsync(entity);
            await this._dbMasterContext.SaveChangesAsync();

            return entity.PK_UUID;
        }

        public async Task<bool> InsertMany(List<TEntity> entities)
        {
            entities.ForEach(async x => await Insert(x));

            await Task.WhenAll();

            return true;
        }

        public async Task<Guid> Update(TEntity entity)
        {
            entity.UpdatedDatetime = DateTime.Now;
            entity.UpdatedBy = entity.UpdatedBy;

            this._dbMasterContext.Update(entity);
            await this._dbMasterContext.SaveChangesAsync();

            return entity.PK_UUID;
        }

        public async Task<bool> Delete(Guid id, string actionBy)
        {
            var enity = await this.FindById(id);

            if (enity == null) return false;

            enity.IsDeleted = true;
            enity.IsActive = false;
            enity.DeletedDatetime = DateTime.Now;
            enity.DeletedBy = actionBy;

            this._dbMasterContext.Update(enity);
            await this._dbMasterContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByParentId(Guid id, string actionBy)
        {
            var entity = await this.FindByParentId(id);

            if (entity == null || entity.Count == 0) return false;

            entity.ForEach(x => x.IsDeleted = true);
            entity.ForEach(x => x.IsActive = false);
            entity.ForEach(x => x.DeletedBy = actionBy);
            entity.ForEach(x => x.DeletedDatetime = DateTime.Now);

            this._dbMasterContext.Update(entity);
            await this._dbMasterContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByCode(string code, string actionBy)
        {
            var entity = await this.FindByCode(code);

            if (entity == null) return false;

            entity.IsDeleted = true;
            entity.IsActive = false;
            entity.DeletedDatetime = DateTime.Now;
            entity.DeletedBy = actionBy;

            this._dbMasterContext.Update(entity);
            await this._dbMasterContext.SaveChangesAsync();

            return true;
        }

        public DbSet<TEntity> GetSet()
        {
            return _uow.CreateSet<TEntity>();
        }

        public IQueryable<TAny> ExecSql<TAny>(string sql, object[]? parameters = null)
            where TAny : class
        {
            return _uow.ExecSql<TAny>(sql, parameters);
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _uow.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>>? filter = null) =>
            filter != null ? GetSet().First(filter) : GetSet().First();

        public virtual TEntity? FirstOrDefault(Expression<Func<TEntity, bool>>? filter = null) =>
            filter != null ? GetSet().FirstOrDefault(filter) : GetSet().FirstOrDefault();

        public virtual IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        public virtual IQueryable<TEntity> GetPaged<TKProperty>(int pageIndex,
            int pageCount,
            Expression<Func<TEntity, bool>>? filter,
            Expression<Func<TEntity, TKProperty>> orderByExpression,
            bool ascending)
        {
            var set = filter != null ? GetSet().Where(filter) : GetSet();
            return ascending
                ? set.OrderBy(orderByExpression)
                    .Skip(pageCount * pageIndex)
                    .Take(pageCount)
                : set.OrderByDescending(orderByExpression)
                    .Skip(pageCount * pageIndex)
                    .Take(pageCount);
        }

        public virtual IQueryable<TEntity> GetAllQueryable()
        {
            return GetSet();
        }

        public virtual TEntity Get(Guid id)
        {
            return GetSet().Find(id);
        }

        public virtual void TrackItem(TEntity? e)
        {
            if (e == null) return;
            _uow.SetAttach(e);
        }

        public virtual void Clear()
        {
            if (!GetSet().Any()) return;
            GetSet().RemoveRange(GetSet());
        }

        public virtual void DeleteAll(TEntity? e)
        {
            if (e == null) return;
            _uow.SetAttach(e);
            GetSet().Remove(e);
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
        }
    }
}
