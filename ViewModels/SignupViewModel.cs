using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "please Enter Name")]
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string DOB { get; set; }
        public string Role { get; set; }
        public string JoinDate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must contain at least one letter and one number.")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Confirm Password must be at least 8 characters long.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
