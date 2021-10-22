using ITrellisCarDealershipAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI
{
    public class CarDealershipDBContext : DbContext
    {

        public virtual DbSet<Car> Cars { get; set; }

        public CarDealershipDBContext(DbContextOptions<CarDealershipDBContext> options)
            :base(options)
        {

        }


    }
}
