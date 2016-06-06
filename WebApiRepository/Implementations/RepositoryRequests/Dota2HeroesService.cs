using System.Collections.Generic;
using System.Linq;
using WebApiRepository.Interfaces;
using WebApiRepository.Models;
using WebApiRepository.UnitOfWork;

namespace WebApiRepository.Implementations.RepositoryRequests
{
    public class Dota2HeroesService : IDota2HeroesService
    {
        #region Fields & constructor

        private readonly IUnitOfWork _unitOfWork;

        public Dota2HeroesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion
        public List<Heroes> GetAllHeroes()
        {
            var heroes = _unitOfWork.Repository<Heroes>().Get().ToList();

            return heroes;
        }
    }
}
