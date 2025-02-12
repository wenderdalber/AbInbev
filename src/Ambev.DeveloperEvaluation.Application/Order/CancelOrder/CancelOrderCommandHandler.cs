using Ambev.DeveloperEvaluation.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.CancelOrder;

/// <summary>
/// Handler to delete an order.
/// </summary>
public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public CancelOrderCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.Id);
        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}