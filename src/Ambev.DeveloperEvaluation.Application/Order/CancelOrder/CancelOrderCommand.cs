using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.CancelOrder;

/// <summary>
/// Command to cancel an order.
/// </summary>
public class CancelOrderCommand : IRequest<bool>
{
    public int Id { get; set; }

    public CancelOrderCommand(int id)
    {
        Id = id;
    }
}
