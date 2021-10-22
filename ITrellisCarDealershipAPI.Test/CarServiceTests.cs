using ITrellisCarDealershipAPI.Models;
using ITrellisCarDealershipAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ITrellisCarDealershipAPI.Test
{
    public class CarServiceTests
    {
        [Fact]
        public async Task GetFilteredCarList_NoPreferenceQuery()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<CarDealershipDBContext>().UseInMemoryDatabase("CarsTest");

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                _db.Add(new Car("a", "Chevy", 2016, "Gray", 16106, false, true, true, false, true, false));
                _db.Add(new Car("b", "Toyota", 2012, "Silver", 18696, true, true, false, true, false, true));
                _db.Add(new Car("c", "Ford", 2014, "Gray", 19710, false, true, false, false, true, true));
                _db.Add(new Car("d", "Toyota", 2014, "Red", 19248, true, false, true, true, true, true));

                await _db.SaveChangesAsync();
            }

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                var carService = new CarService(_db);
                var query = new CarQuery();

                List<Car> carQueryResult = await carService.GetFilteredCarList(query);

                Assert.Equal(4, carQueryResult.Count);
            }
        }

        [Fact]
        public async Task GetFilteredCarList_SpecificColorQuery()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<CarDealershipDBContext>().UseInMemoryDatabase("CarsColorTest");

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                _db.Add(new Car("a", "Chevy", 2016, "Gray", 16106, false, true, true, false, true, false));
                _db.Add(new Car("b", "Toyota", 2012, "Silver", 18696, true, true, false, true, false, true));
                _db.Add(new Car("c", "Ford", 2014, "Gray", 19710, false, true, false, false, true, true));
                _db.Add(new Car("d", "Toyota", 2014, "Red", 19248, true, false, true, true, true, true));

                await _db.SaveChangesAsync();
            }

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                var carService = new CarService(_db);
                var query = new CarQuery();
                query.Color = "Gray";

                List<Car> carQueryResult = await carService.GetFilteredCarList(query);

                Assert.Equal(2, carQueryResult.Count);
                Assert.All<Car>(carQueryResult, c => Assert.Equal("Gray", c.color));
            }
        }

        [Fact]
        public async Task GetFilteredCarList_AllOptionsSelected()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<CarDealershipDBContext>().UseInMemoryDatabase("CarsAllOptionsTest");

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                _db.Add(new Car("a", "Chevy", 2016, "Gray", 16106, false, true, true, false, true, false));
                _db.Add(new Car("b", "Toyota", 2012, "Silver", 18696, true, true, false, true, false, true));
                _db.Add(new Car("c", "Ford", 2014, "Gray", 19710, false, true, false, false, true, true));
                _db.Add(new Car("d", "Toyota", 2014, "Red", 19248, true, false, true, true, true, true));
                _db.Add(new Car("e", "Honda", 2014, "Blue", 29248, true, true, true, true, true, true));
                _db.Add(new Car("f", "Jeep", 2014, "Black", 15248, false, false, false, false, false, false));

                await _db.SaveChangesAsync();
            }

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                var carService = new CarService(_db);
                var query = new CarQuery()
                {
                    HasSunroof = true,
                    IsFourWheelDrive = true,
                    HasLowMiles = true,
                    HasPowerWindows = true,
                    HasNavigation = true,
                    HasHeatedSeats = true
                };

                List<Car> carQueryResult = await carService.GetFilteredCarList(query);

                Assert.Single(carQueryResult);
                Assert.Equal("e", carQueryResult[0]._id);
            }
        }

        [Fact]
        public async Task GetFilteredCarList_NoOptionsSelected()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<CarDealershipDBContext>().UseInMemoryDatabase("CarsNoOptionsTest");

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                _db.Add(new Car("a", "Chevy", 2016, "Gray", 16106, false, true, true, false, true, false));
                _db.Add(new Car("b", "Toyota", 2012, "Silver", 18696, true, true, false, true, false, true));
                _db.Add(new Car("c", "Ford", 2014, "Gray", 19710, false, true, false, false, true, true));
                _db.Add(new Car("d", "Toyota", 2014, "Red", 19248, true, false, true, true, true, true));
                _db.Add(new Car("e", "Honda", 2014, "Blue", 29248, true, true, true, true, true, true));
                _db.Add(new Car("f", "Jeep", 2014, "Black", 15248, false, false, false, false, false, false));

                await _db.SaveChangesAsync();
            }

            using (var _db = new CarDealershipDBContext(dbOptionsBuilder.Options))
            {
                var carService = new CarService(_db);
                var query = new CarQuery()
                {
                    HasSunroof = false,
                    IsFourWheelDrive = false,
                    HasLowMiles = false,
                    HasPowerWindows = false,
                    HasNavigation = false,
                    HasHeatedSeats = false
                };

                List<Car> carQueryResult = await carService.GetFilteredCarList(query);

                Assert.Single(carQueryResult);
                Assert.Equal("f", carQueryResult[0]._id);
            }
        }
    }
}
