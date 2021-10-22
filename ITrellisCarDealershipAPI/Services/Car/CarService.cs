using ITrellisCarDealershipAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealershipDBContext _db;

        public CarService(CarDealershipDBContext db)
        {
            _db = db;
        }

        public async Task<List<Car>> GetFilteredCarList(CarQuery carQuery)
        {
            IQueryable<Car> query = _db.Cars;

            //null = no preference, otherwise we use the preferred property. thus if someone doesn't want to see any cars with sunroofs they can select "no sunroof"

            if (carQuery.Color != null)
            {
                query = query.Where(c => c.color == carQuery.Color);
            }

            if (carQuery.HasSunroof != null)
            {
                query = query.Where(c => c.hasSunroof == carQuery.HasSunroof);
            }

            if (carQuery.IsFourWheelDrive != null)
            {
                query = query.Where(c => c.isFourWheelDrive == carQuery.IsFourWheelDrive);
            }

            if (carQuery.HasLowMiles != null)
            {
                query = query.Where(c => c.hasLowMiles == carQuery.HasLowMiles);
            }

            if (carQuery.HasPowerWindows != null)
            {
                query = query.Where(c => c.hasPowerWindows == carQuery.HasPowerWindows);
            }

            if (carQuery.HasNavigation != null)
            {
                query = query.Where(c => c.hasNavigation == carQuery.HasNavigation);
            }

            if (carQuery.HasHeatedSeats != null)
            {
                query = query.Where(c => c.hasHeatedSeats == carQuery.HasHeatedSeats);
            }

            return await query.ToListAsync();
        }

        public void RemoveAll()
        {
            _db.Database.EnsureDeleted();
            _db.SaveChanges();
        }
    }
}
