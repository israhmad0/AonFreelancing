using AonFreelancing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AonFreelancing.Contexts
{
    public class MainAppContext:IdentityDbContext<User, ApplicationRole, long>
    {
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public MainAppContext(DbContextOptions<MainAppContext> contextOptions) : base(contextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Freelancer>().HasBaseType(typeof(User));
            builder.Entity<Client>().HasBaseType(typeof(User));
            builder.Entity<SystemUser>().HasBaseType(typeof(User));
            base.OnModelCreating(builder);
        }

    }
}
