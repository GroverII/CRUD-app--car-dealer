using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class FuelType
    {
        public int Id { get; set; }
        [Display(Name = "Fuel Name")]
        [DisplayFormat(NullDisplayText = "No Name")]
        public required string Name { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
