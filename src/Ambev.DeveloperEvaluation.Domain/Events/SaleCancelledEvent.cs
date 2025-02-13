using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events;

/// <summary>
/// Event triggered when a sale is cancelled.
/// </summary>
public class SaleCancelledEvent : INotification
{
    public Order Order { get; }

    public SaleCancelledEvent(Order order)
    {
        Order = order;
    }
}
