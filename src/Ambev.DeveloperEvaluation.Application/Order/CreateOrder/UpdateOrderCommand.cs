using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

/// <summary>
/// Command to update an existing order.
/// </summary>
public class UpdateOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Status { get; set; }
    public List<OrderItemDto> Items { get; set; }

    public UpdateOrderCommand(int id, string status, List<OrderItemDto> items)
    {
        Id = id;
        Status = status;
        Items = items;
    }
}