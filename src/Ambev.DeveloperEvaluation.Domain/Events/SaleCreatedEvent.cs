using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events;

/// <summary>
/// Event triggered when a sale is created.
/// </summary>
public class SaleCreatedEvent : INotification
{
    public Order Order { get; }

    public SaleCreatedEvent(Order order)
    {
        Order = order;
    }
}