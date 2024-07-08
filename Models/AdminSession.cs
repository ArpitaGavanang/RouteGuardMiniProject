using System;
using System.Collections.Generic;

namespace RouteGuardProject.Models;

public partial class AdminSession
{
    public int Id { get; set; }

    public int AdminId { get; set; }

    public string Token { get; set; } = null!;

    public string LoginAt { get; set; } = null!;

    public virtual Admin Admin { get; set; } = null!;
}
