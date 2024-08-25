using CK.Central.Core.Domain.DataObjects.CMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Auth.DbContexts
{
    public class AuthDbContext : IdentityDbContext<ApplicationUserModel, ApplicationRoleModel, string>
    {
        public DbSet<ApplicationUserModel> applicationUsers { get; set; }
        public DbSet<ApplicationRoleModel> applicationRoles { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration Configuration = builder.Build();

            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("MasterPgsqlDbConnection"), builder =>
            {
                builder.MigrationsAssembly("CK.Central.API.CMS.Auth");
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserModel>().ToTable("AspNetUser");

            builder.Entity<ApplicationRoleModel>().ToTable("AspNetRole");

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("AspNetUserRole");
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("AspNetUserClaim");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("AspNetUserLogin");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("AspNetRoleClaim");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("AspNetUserToken");
            });
        }
    }
}
