using System;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an individual item in an order, including the product and pricing details.
/// </summary>
public class Item
{
    /// <summary>
    /// Gets or sets the unique identifier for the item.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this item.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total price after applying the discount.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Gets or sets the quantity of this product in the order.
    /// </summary>
    public int Quantity { get; set; }
}
