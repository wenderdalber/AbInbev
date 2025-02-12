using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder;

/// <summary>
/// Command to create a new order.
/// </summary>
public class CreateOrderCommand : IRequest<int>
{
    public string Number { get; set; }
    public int UserId { get; set; }
    public decimal Total { get; set; }
    public string Filial { get; set; }
    public string Status { get; set; }
    public List<OrderItemDto> Items { get; set; }

    public CreateOrderCommand(string number, int userId, decimal total, string filial, string status, List<OrderItemDto> items)
    {
        Number = number;
        UserId = userId;
        Total = total;
        Filial = filial;
        Status = status;
        Items = items;
    }
}

public class OrderItemDto
{
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
