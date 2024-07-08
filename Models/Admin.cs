using System;
using System.Collections.Generic;

namespace RouteGuardProject.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Dob { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string JoinDate { get; set; } = null!;

    public string Permissions { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public virtual ICollection<AdminSession> AdminSessions { get; set; } = new List<AdminSession>();
}
