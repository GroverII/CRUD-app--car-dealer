using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUD.Data;
using System;
using System.Linq;

namespace CRUD.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CRUDContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CRUDContext>>()))
        {
            if (context.Car.Any())
            {
                return;   // DB has been seeded
            }

            context.Car.AddRange(
                    new Car
                    {
                        BrandId = 1,
                        FuelTypeId = 1, 
                        Model="Anasagasti",
                        Color=Color.blue,
                        ManufacturingDate=DateTime.Parse("2005-09-01"), 
                        Price=13000,
                        Brand = new Brand { Name = "Anasagasti" },
                        FuelType = new FuelType { Name = "Diesel" }
                    },
                    new Car
                    {
                        BrandId = 2, 
                        FuelTypeId = 2,
                        Model="Zanella",
                        Color=Color.red,
                        ManufacturingDate=DateTime.Parse("2005-09-01"), 
                        Price=5000,
                        Brand = new Brand { Name = "Zanella" },
                        FuelType = new FuelType { Name = "Petrol" }
                    },
                    new Car
                    {
                        BrandId = 3, 
                        FuelTypeId = 2,
                        Model="Andino",
                        Color=Color.white,
                        ManufacturingDate=DateTime.Parse("2005-09-01"), 
                        Price=2000,
                        Brand = new Brand { Name = "Zanella" },
                        FuelType = new FuelType { Name = "Electric" }
                    },
                    new Car
                    {
                        BrandId = 4, 
                        FuelTypeId = 2,
                        Model="ASA",
                        Color=Color.green,
                        ManufacturingDate=DateTime.Parse("2005-09-01"), 
                        Price=10000,
                        Brand = new Brand { Name = "Andino" },
                        FuelType = new FuelType { Name = "Diesel" }
                    }
            );
            context.SaveChanges();

            context.FuelType.AddRange(
                new FuelType
                {
                    Name = "Petrol"
                },
                new FuelType
                {
                    Name = "Diesel"
                },
                new FuelType
                {
                    Name = "Electric"
                }
            );
            context.SaveChanges();

            context.Brand.AddRange(
                new Brand
                {
                    Name="Anasagasti"
                },
                new Brand
                {
                    Name="Zanella"
                },
                new Brand
                {
                    Name="Andino"
                },
                new Brand
                {
                    Name="ASA"
                }
            );
            context.SaveChanges();
        }
    }
}