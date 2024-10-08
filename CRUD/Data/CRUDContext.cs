using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data
{
    public class CRUDContext : DbContext
    {
        public CRUDContext (DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD.Models.Car> Car { get; set; } = default!;
        public DbSet<CRUD.Models.Brand> Brand { get; set; } = default!;
        public DbSet<CRUD.Models.FuelType> FuelType { get; set; } = default!;
    }
}
