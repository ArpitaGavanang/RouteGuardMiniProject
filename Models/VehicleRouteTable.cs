using System;
using System.Collections.Generic;

namespace RouteGuardProject.Models;

public partial class VehicleRouteTable
{
    public int Id { get; set; }

    public string DriverName { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string LicenseDate { get; set; } = null!;

    public string LicenseExpiryDate { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public string VehicleNumber { get; set; } = null!;

    public string DistanceTravelByVehicle { get; set; } = null!;

    public string Source { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string ModifiedAt { get; set; } = null!;

    public string ModifiedBy { get; set; } = null!;

    public string DummyColumn1 { get; set; } = null!;

    public string DummyColumn2 { get; set; } = null!;
}
