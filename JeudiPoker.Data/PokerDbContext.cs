using System.Data.Entity;
using JeudiPoker.Data.Configuration;
using JeudiPoker.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JeudiPoker.Data
{
    public class PokerDbContext : IdentityDbContext<ApplicationUser>
    {
        public PokerDbContext() : base("PokerEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionResult> SessionResults { get; set; }

        public virtual void Commit()
        {
            SaveChanges();
        }

        public static PokerDbContext Create()
        {
            return new PokerDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new SessionConfiguration());
            modelBuilder.Configurations.Add(new SessionResultConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}