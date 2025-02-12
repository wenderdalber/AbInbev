using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Order.GetOrder;

/// <summary>
/// Query to get an order by ID.
/// </summary>
public class GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }

    public GetOrderByIdQuery(int id)
    {
        Id = id;
    }
}
