using System;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents geographical coordinates (latitude and longitude).
/// </summary>
public class Geolocation
{
    /// <summary>
    /// Gets or sets the unique identifier for the geolocation entry.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate.
    /// </summary>
    public double Lat { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate.
    /// </summary>
    public double Long { get; set; }
}
