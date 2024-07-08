using System;
using System.Collections.Generic;

namespace RouteGuardProject.Models;

public partial class SuperAdminSession
{
    public int Id { get; set; }

    public int SuperAdminId { get; set; }

    public string Token { get; set; } = null!;

    public string LoginAt { get; set; } = null!;

    public virtual SuperAdmin SuperAdmin { get; set; } = null!;
}
