using System.Collections.Generic;
using System.Linq;
using ViewModels;
using WebApiRepository.Models;

namespace WebApiRepository.Mappers.ModelMappers
{
    public static class HeroesMapper
    {
        public static List<HeroesViewModel> ToViewModel(this List<Heroes> heroes)
        {
            return heroes.Select(x => x.ToViewModel()).ToList();
        }


        public static HeroesViewModel ToViewModel(this Heroes hero)
        {
            var vm = new HeroesViewModel
            {
                Id = hero.Id,
                Name = hero.Name,
                ValveName = hero.ValveHeroName,
                CloudinaryUrl = hero.HeroImage.SmaillImageCloudinaryUrl
            };

            return vm;
        }
    }
}
