using System;
using System.ComponentModel.DataAnnotations;

namespace DriverCRUD.Models;

public class UpdateDriverBody
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
}