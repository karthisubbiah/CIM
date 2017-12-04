using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CarsInventoryApp.Models
{
    public class CarSearch
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<Cars> Cars { get; set; }
    }
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool New { get; set; }
        public int UserId { get; set; }
    }
}