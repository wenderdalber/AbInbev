using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events;

/// <summary>
/// Event triggered when an item inside a sale is cancelled.
/// </summary>
public class ItemCancelledEvent : INotification
{
    public Item Item { get; }
    public Order Order { get; }

    public ItemCancelledEvent(Item item, Order order)
    {
        Item = item;
        Order = order;
    }
}