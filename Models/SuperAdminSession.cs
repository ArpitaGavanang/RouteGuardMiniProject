using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.Models;

public partial class SuperAdminSession
{
    public int Id { get; set; }
    [Required]
    public int SuperAdminId { get; set; } 
    [Required]
    public string Token { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Date of Birth must be in the format YYYY-MM-DD")]
    public DateTime LoginAt { get; set; } 

    public virtual SuperAdmin SuperAdmin { get; set; } = null!;
}
