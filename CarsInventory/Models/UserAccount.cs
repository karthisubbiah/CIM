using System.ComponentModel.DataAnnotations;
namespace CarsInventoryApp.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #region confirm Password
        //[Required(ErrorMessage = "Confirm Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        #endregion        
        public string Name { get; set; }
    }
}