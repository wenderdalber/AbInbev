using System;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product available for purchase.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title or name of the product.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a detailed description of the product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the category of the product (e.g., Electronics, Clothing).
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the URL of the product's image.
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// Gets or sets the rating details of the product.
    /// </summary>
    public Rating Rating { get; set; }
}
