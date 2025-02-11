using System;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents the rating of a product based on user reviews.
/// </summary>
public class Rating
{
    /// <summary>
    /// Gets or sets the unique identifier for the rating.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the average rating of the product (e.g., 4.5 stars).
    /// </summary>
    public double Rate { get; set; }

    /// <summary>
    /// Gets or sets the total number of reviews for this product.
    /// </summary>
    public int Count { get; set; }
}
