using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.DbContexts
{
    public static class DbContextExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IList<T> SqlQuery<T>(this DbContext db, string sql, params object[] parameters) where T : class
        {
            using var db2 = new ContextForQueryType<T>(db.Database.GetDbConnection());
            return db2.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        public static IList<T> ExecSql<T>(this DbContext db, string sql, params object[]? parameters) where T : class
        {
            using var db2 = new ContextForQueryType<T>(db.Database.GetDbConnection());
            return db2.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class ContextForQueryType<T> : DbContext
            where T : class
        {
            private readonly DbConnection _connection;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="connection"></param>
            public ContextForQueryType(DbConnection connection)
            {
                _connection = connection;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="optionsBuilder"></param>
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(_connection, options => options.EnableRetryOnFailure());

                base.OnConfiguring(optionsBuilder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="modelBuilder"></param>
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<T>().HasNoKey();
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
