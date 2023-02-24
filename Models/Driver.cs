using System;
using System.ComponentModel.DataAnnotations;

namespace DriverCRUD.Models;

public class Driver
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [EmailAddress][Required]
    public string? Email { get; set; }
    [Phone][Required]
    public string? PhoneNumber { get; set; }
}