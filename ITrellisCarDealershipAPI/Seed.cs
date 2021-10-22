using ITrellisCarDealershipAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI
{
    public class Seed
    {
        private readonly CarDealershipDBContext _db;

        public Seed(CarDealershipDBContext db)
        {
            _db = db;
        }

        public void SeedCars()
        {
            var carData = System.IO.File.ReadAllText("CarData.json");
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(carData);

            foreach(Car car in cars)
            {
                _db.Cars.Add(car);
            }

            _db.SaveChanges();
        }
    }
}
