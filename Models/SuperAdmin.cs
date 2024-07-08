using System;
using System.Collections.Generic;

namespace RouteGuardProject.Models;

public partial class SuperAdmin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Dob { get; set; } = null!;

    public string JoinDate { get; set; } = null!;

    public virtual ICollection<SuperAdminSession> SuperAdminSessions { get; set; } = new List<SuperAdminSession>();
}
