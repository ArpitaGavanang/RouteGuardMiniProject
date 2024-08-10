using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.Models;

public partial class AdminSession
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int AdminId { get; set; }
    [Required]
    public string Token { get; set; } = null!;
    [Required]
    public DateTime LoginAt { get; set; }

    public virtual Admin Admin { get; set; } = null!;
}
