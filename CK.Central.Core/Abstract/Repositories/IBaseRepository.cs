using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using CK.Central.Core.DataObjects.Entity;
using CK.Central.Core.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.Abstract.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IUnitOfWork UOW { get; }

        Task<List<TEntity>> GetAllSlave();
        Task<TEntity> FindByIdSlave(Guid id);
        Task<List<TEntity>> FindByParentIdSlave(Guid id);
        Task<TEntity> FindByCodeSlave(string code);
        Task<IEnumerable<TEntity>> FilterSlave(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAllActive();
        Task<TEntity> FindById(Guid id);
        Task<List<TEntity>> FindByParentId(Guid id);
        Task<TEntity> FindByCode(string name);
        Task<Guid> Insert(TEntity entity);
        Task<bool> InsertMany(List<TEntity> entities);
        Task<Guid> Update(TEntity entity);
        Task<bool> Delete(Guid id, string action_by);
        Task<bool> DeleteByParentId(Guid id, string action_by);
        Task<bool> DeleteByCode(string code, string action_by);
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        DbSet<TEntity> GetSet();
        IQueryable<TAny> ExecSql<TAny>(string sql, object[]? parameters = null)
            where TAny : class;
        TEntity First(Expression<Func<TEntity, bool>>? filter);
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetPaged<TKProperty>(int pageIndex,
            int pageCount, Expression<Func<TEntity, bool>>? filter,
            Expression<Func<TEntity, TKProperty>> orderByExpression,
            bool ascending);
        IQueryable<TEntity> GetAllQueryable();
        void Merge(TEntity persisted, TEntity current);
        TEntity Get(Guid id);
        void TrackItem(TEntity? e);
        void Clear();
        void DeleteAll(TEntity? item);
    }
}
