using System.Data.Entity;
using WebApiRepository.Models;

namespace WebApiRepository
{
    public class SqlLiteContext : DbContext
    {
       public SqlLiteContext() : base("name=Dota2Db") { }

        public DbSet<Heroes> Heroes { get; set; }

        public DbSet<HeroesImages> HeroImage { get; set; }

        protected override void OnModelCreating(DbModelBuilder mdb)
        {
            mdb.Entity<HeroesImages>()
                .HasKey(e => e.HeroId);

            mdb.Entity<Heroes>()
                .HasRequired(s => s.HeroImage)
                .WithRequiredPrincipal(s => s.Heroes);
        }
    }
}
