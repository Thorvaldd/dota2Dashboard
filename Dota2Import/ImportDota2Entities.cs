using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiRepository;
using WebApiRepository.Implementations;
using WebApiRepository.Models;

namespace Dota2Import
{
    public static class ImportDota2Entities
    {
        public static void ImportHeroes()
        {
            var apiRepo = new Dota2Results();
            var heroesResult = apiRepo.GetHores().Result;
            using (var ctx = new SqlLiteContext())
            {
                foreach (var hero in heroesResult.Heroes)
                {
                    var herEntity = new WebApiRepository.Models.Heroes
                    {
                        Id = hero.Id,
                        Name = hero.Name,
                        ValveHeroName = hero.ValveName
                    };

                    Console.WriteLine("Saving -> {0}", hero.Name);

                    ctx.Heroes.Add(herEntity);
                }
                ctx.SaveChanges();
            }

        }

        public static async void ImportSmallHeroIcons()
        {
            var apiHero = new Dota2Results();
            using (var db = new SqlLiteContext())
            {
                var dbHeroes = db.Heroes.ToList();
                var id = 0;
                foreach (var dbHero in dbHeroes)
                {
                    id++;
                    var byteResult = await apiHero.HeroImage(dbHero.ValveHeroName, 0);
                    var heroImage = new HeroesImages
                    {

                        Blob = byteResult,
                        HeroId = dbHero.Id,
                        Id = id
                    };
                    db.HeroImage.Add(heroImage);
                    Console.WriteLine("Added {0} image", dbHero.Name);
                }
                db.SaveChanges();
            }

        }
    }
}
