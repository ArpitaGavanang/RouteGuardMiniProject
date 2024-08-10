using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.Models;

public partial class Admin
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Please Enter Valid Name")]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Department { get; set; }

    [Required]
    [StringLength(100)]
    public string Designation { get; set; }

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Date of Birth must be in the format YYYY-MM-DD")]
    public string Dob { get; set; }

    public string Role { get; set; }
    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Join Date must be in the format YYYY-MM-DD")]
    public string JoinDate { get; set; }
    [Required]
    [StringLength(100)]
    public string Permissions { get; set; }
    [Required]
    [StringLength(100)]
    public string CreatedBy { get; set; }
    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Created At must be in the format YYYY-MM-DD")]
    public string CreatedAt { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must contain at least one letter and one number.")]
    public string Password { get; set; }

    public virtual ICollection<AdminSession> AdminSessions { get; set; } = new List<AdminSession>();
}
