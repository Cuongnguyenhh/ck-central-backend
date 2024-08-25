using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.DbContexts
{
    public class DbContextBase : DbContext, IDbContextBase
    {

        public string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DbContextBase(DbContextOptions options)
            : base(options)
        {
            //ConnectionString = connectionString;
            //Database.CommandTimeout = 600;
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.LazyLoadingEnabled = true;
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <type-param name="T"></type-param>
        /// <returns></returns>
        public static T Create<T>() where T : new()
        {
            return new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public DbSet<T> CreateSet<T>()
            where T : class
        {
            return Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void SetAttach<T>(T item)
            where T : class
        {
            Entry(item).State = EntityState.Unchanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void SetModified<T>(T item)
            where T : class
        {
            Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <param name="current"></param>
        public void ApplyCurrentValues<T>(T original, T current)
            where T : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {

            try
            {
                SaveChanges();
            }
            catch (ValidationException)
            {
                throw;
                //var error = string.Empty;
                //foreach (var eve in ex.EntityValidationErrors)
                //{
                //    if (error.Length > 0) error += ",";
                //    error += "[";
                //    error += eve.Entry.Entity.GetType().Name;
                //    error += eve.Entry.State;
                //    error += ":";
                //    error = eve.ValidationErrors.Aggregate(error,
                //        (current, ve) => current + "(" + ve.PropertyName + ":" + ve.ErrorMessage + ")");
                //    error += "]";
                //}
                //throw new Exception(error);
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CommitAndRefreshChanges()
        {
            bool saveFailed;

            do
            {
                try
                {
                    SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList()
                        .ForEach(entry =>
                        {
                            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        });
                }
            } while (saveFailed);

        }

        /// <summary>
        /// 
        /// </summary>
        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExecSql<T>(string sql, object[]? parameters)
            where T : class
        {
            parameters ??= Array.Empty<object>();
            return DbContextExtensions.ExecSql<T>(this, sql, parameters).AsQueryable();
        }
    }
}
