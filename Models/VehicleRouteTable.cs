using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.Models;

public partial class VehicleRouteTable
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string DriverName { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "Date of Birth must be in the format YYYY-MM-DD")]
    public string DateOfBirth { get; set; } = null!;

    public string Address { get; set; } = null!;

    [Required]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
    public string PhoneNo { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "License Date must be in the format YYYY-MM-DD")]
    public string LicenseDate { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "License Expiry Date must be in the format YYYY-MM-DD")]
    public string LicenseExpiryDate { get; set; } = null!;

    [Required]
    public string VehicleModel { get; set; } = null!;

    [Required]
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
