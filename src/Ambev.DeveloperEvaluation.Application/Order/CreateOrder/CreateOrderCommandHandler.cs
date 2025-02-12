using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

/// <summary>
/// Handler to create an order.
/// </summary>
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateOrderCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user == null)
            throw new KeyNotFoundException("User not found.");

        var order = new Order
        {
            Number = request.Number,
            User = user,
            Filial = request.Filial,
            Status = request.Status,
            Items = request.Items.Select(i => new Item
            {
                Product = _context.Products.Find(i.ProductId),
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity
            }).ToList()
        };

        order.ApplyDiscounts(); // Aplica as regras de desconto

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);
        return order.Id;
    }
}