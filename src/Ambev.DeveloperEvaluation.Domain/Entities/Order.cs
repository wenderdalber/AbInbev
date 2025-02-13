using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an order made by a user, containing purchased items and payment details.
/// </summary>
public class Order
{
    private readonly IMediator _mediator;

    public Order(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CreateAsync()
    {
        await _mediator.Publish(new SaleCreatedEvent(this));
    }

    public async Task ModifyAsync()
    {
        await _mediator.Publish(new SaleModifiedEvent(this));
    }

    public async Task CancelAsync()
    {
        await _mediator.Publish(new SaleCancelledEvent(this));
    }

    public async Task CancelItemAsync(Item item)
    {
        await _mediator.Publish(new ItemCancelledEvent(item, this));
    }

    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the order number, which uniquely identifies the order.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the date and time the order was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the user who placed the order.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the order after applying discounts.
    /// </summary>
    public decimal Total { get; private set; }

    /// <summary>
    /// Gets or sets the store branch where the order was placed.
    /// </summary>
    public string Filial { get; set; }

    /// <summary>
    /// Gets or sets the order status (e.g., Pending, Completed, Canceled).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the order.
    /// </summary>
    public List<Item> Items { get; set; } = new List<Item>();

    /// <summary>
    /// Calculates and applies discounts based on the quantity of identical items in the order.
    /// </summary>
    public void ApplyDiscounts()
    {
        if (Items == null || !Items.Any())
            return;

        foreach (var itemGroup in Items.GroupBy(i => i.Product.Id))
        {
            var quantity = itemGroup.Sum(i => i.Quantity);

            if (quantity > 20)
            {
                throw new InvalidOperationException($"Não é permitido comprar mais de 20 unidades do produto {itemGroup.First().Product.Title}.");
            }

            foreach (var item in itemGroup)
            {
                if (quantity >= 10 && quantity <= 20)
                {
                    item.Discount = item.UnitPrice * 0.20m; // 20% de desconto
                }
                else if (quantity == 4)
                {
                    item.Discount = item.UnitPrice * 0.10m; // 10% de desconto
                }
                else
                {
                    item.Discount = 0; // Sem desconto para menos de 4 unidades
                }

                item.Total = (item.UnitPrice - item.Discount) * item.Quantity;
            }
        }

        // Recalcula o total do pedido
        Total = Items.Sum(i => i.Total);
    }
}

