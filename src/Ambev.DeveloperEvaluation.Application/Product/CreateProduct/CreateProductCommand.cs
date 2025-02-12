using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

/// <summary>
/// Command to create a new product.
/// </summary>
public class CreateProductCommand : IRequest<int>
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }

    public CreateProductCommand(string title, decimal price, string description, string category, string image)
    {
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
    }
}
