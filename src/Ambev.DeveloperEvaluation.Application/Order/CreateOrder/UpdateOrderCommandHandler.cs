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
/// Handler to update an order.
/// </summary>
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateOrderCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        if (order == null)
            return false;

        order.Status = request.Status;
        order.Items.Clear();
        order.Items.AddRange(request.Items.Select(i => new Item
        {
            Product = _context.Products.Find(i.ProductId),
            UnitPrice = i.UnitPrice,
            Quantity = i.Quantity
        }));

        order.ApplyDiscounts();

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
