using System.Data.Entity;
using WebApiRepository.Models;

namespace WebApiRepository
{
    public class ApplicationContext : DbContext
    {
       public ApplicationContext() : base("name=1gbD2api") { }

        public DbSet<Heroes> Heroes { get; set; }

        public DbSet<HeroesImages> HeroImage { get; set; }

        public DbSet<GameItems> GameItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder mdb)
        {
            mdb.Entity<HeroesImages>()
                .HasKey(e => e.HeroId);

            mdb.Entity<Heroes>()
                .HasRequired(s => s.HeroImage)
                .WithRequiredPrincipal(s => s.Heroes);

            mdb.Entity<GameItems>()
                .HasKey(e => e.Id);
        }
    }
}
