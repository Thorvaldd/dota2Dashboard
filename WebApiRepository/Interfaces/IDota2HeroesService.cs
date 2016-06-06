using System;
using System.Collections.Generic;
using WebApiRepository.Models;

namespace WebApiRepository.Interfaces
{
    public interface IDota2HeroesService
    {
        List<Heroes> GetAllHeroes();
    }
}