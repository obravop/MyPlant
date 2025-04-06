using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPlant.Models;

namespace MyPlant.Data
{
    public class MyPlantContext : DbContext
    {
        public MyPlantContext (DbContextOptions<MyPlantContext> options)
            : base(options)
        {
        }

        public DbSet<MyPlant.Models.Plant> Plant { get; set; } = default!;
        public DbSet<MyPlant.Models.PlantType> PlantType { get; set; } = default!;
        public DbSet<MyPlant.Models.PlantLocation> PlantLocation { get; set; } = default!;
    }
}
