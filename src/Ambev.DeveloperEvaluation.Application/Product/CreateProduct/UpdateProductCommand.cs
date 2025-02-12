using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

/// <summary>
/// Command to update an existing product.
/// </summary>
public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }

    public UpdateProductCommand(int id, string title, decimal price, string description, string category, string image)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
    }
}
