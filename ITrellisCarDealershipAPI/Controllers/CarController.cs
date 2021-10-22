using AutoMapper;
using ITrellisCarDealershipAPI.Models;
using ITrellisCarDealershipAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI.Controllers
{
    [Route("/api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CarDTO>> GetFilteredCarList(CarQuery carQuery)
        {
            if (carQuery.Color == "null")
            {
                carQuery.Color = null;
            }
            List<Car> carQueryResult = await _carService.GetFilteredCarList(carQuery);

            return _mapper.Map<List<CarDTO>>(carQueryResult);
        }
    }
}
