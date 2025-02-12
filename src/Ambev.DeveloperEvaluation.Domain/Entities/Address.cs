using System;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a user's address, including location, phone, and status.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the unique identifier for the address.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the city where the user resides.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the street name.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Gets or sets the house/building number.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the postal code (CEP).
    /// </summary>
    public string Zipcode { get; set; }

    /// <summary>
    /// Gets or sets the geographical location (latitude and longitude).
    /// </summary>
    public Geolocation Geolocation { get; set; }

    /// <summary>
    /// Gets or sets the contact phone number.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the status of the address (e.g., Active, Inactive).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the address (e.g., Residential, Business).
    /// </summary>
    public string Role { get; set; }
}
