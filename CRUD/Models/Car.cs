using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace CRUD.Models
{
    public enum Color
    {
        green, blue, red, black, white 
    }
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public required Brand Brand { get; set; }
        public int FuelTypeId { get; set; }
        public required FuelType FuelType { get; set; }
        public string? Model { get; set; }
        public Color? Color { get; set; }
        public int Mileage { get; set; }
        [Display(Name = "Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }
        public decimal Price { get; set; }
    }
}
