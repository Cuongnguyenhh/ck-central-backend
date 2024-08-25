using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.Abstract.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        DatabaseFacade Database { get; }

        /// <summary>
        /// 
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context, 
        /// the ObjectStateManager, and the underlying store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> CreateSet<T>() where T : class;

        /// <summary>
        /// SetAttach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item</param>
        void SetAttach<T>(T item) where T : class;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The entity item to set as modified</param>
        void SetModified<T>(T item) where T : class;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<T>(T original, T current) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExecSql<T>(string sql, params object[]? parameters)
            where T : class;

        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,  
        /// then an exception is thrown
        ///</remarks>
        void Commit();

        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then 'client changes' are refreshed - Client wins
        ///</remarks>
        void CommitAndRefreshChanges();

        /// <summary>
        /// Rollback tracked changes. See references of UnitOfWork pattern
        /// </summary>
        void RollbackChanges();

    }
}
