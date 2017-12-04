using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarsInventoryApp.Models
{
    public class CarInventory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50)]
        [MaxLength(50), MinLength(1)]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is required")]
        [StringLength(50)]
        [MaxLength(50), MinLength(1)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid year")]
        [Range(1000, 2017, ErrorMessage = "Year can only be between 1000 .. 2017")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Price cannot be zero")]
        public decimal Price { get; set; }
        [DisplayName("Is New")]
        public bool New { get; set; }
    }
}