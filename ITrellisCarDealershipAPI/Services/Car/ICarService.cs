using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITrellisCarDealershipAPI.Models;

namespace ITrellisCarDealershipAPI.Services
{
    public interface ICarService
    {
        Task<List<Car>> GetFilteredCarList(CarQuery carQuery);
        void RemoveAll();
    }
}
