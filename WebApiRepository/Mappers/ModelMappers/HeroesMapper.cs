﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebApiRepository.Models;
using WebApiRepository.ViewModels;

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
                HeroImage = new byte[0], //hero.HeroImage.Blob,
                Base64Image = ""//Convert.ToBase64String(hero.HeroImage.Blob)
            };

            return vm;
        }
    }
}
