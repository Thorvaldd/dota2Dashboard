using System.Collections.Generic;
using System.Linq;
using Dota2Api.ApiClasses;
using Dota2Api.Results;
using WebApiRepository.ViewModels;

namespace WebApiRepository.Mappers.ApiMappers
{
    public static class HeroesMapper
    {
        public static HeroResultsViewModel ToViewModel(this HeroResult heroes)
        {
            var vm = new HeroResultsViewModel
            {
                Heroes = heroes.Heroes.ToVieModel()
            };

            return vm;
        }

        public static List<HeroesViewModel> ToVieModel(this List<Hero> heroes)
        {
            return heroes.Select(x => x.ToViewModel()).ToList();
        }

        public static HeroesViewModel ToViewModel(this Hero hero)
        {
            var vm = new HeroesViewModel
            {
                Id = hero.Id,
                Name = hero.Name,
                ValveName = hero.ValveName
            };

            return vm;
        }
    }
}