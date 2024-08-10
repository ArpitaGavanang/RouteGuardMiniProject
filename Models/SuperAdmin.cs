using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.Models;

public partial class SuperAdmin
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Role { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Department { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Designation { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Date of Birth must be in the format YYYY-MM-DD")]
    public string Dob { get; set; }

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Join Date must be in the format YYYY-MM-DD")]
    public string JoinDate { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must contain at least one letter and one number.")]
    public string Password { get; set; }

    public virtual ICollection<SuperAdminSession> SuperAdminSessions { get; set; } = new List<SuperAdminSession>();
}
