using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Unit tests for Order entity.
/// </summary>
public class OrderTests
{
    private readonly Mock<IMediator> _mediatorMock;

    public OrderTests()
    {
        _mediatorMock = new Mock<IMediator>();
    }

    /// <summary>
    /// Test to verify that a sale creation triggers the SaleCreatedEvent.
    /// </summary>
    [Fact]
    public async Task CreateOrder_ShouldTriggerSaleCreatedEvent()
    {
        // Arrange
        var order = new Order(_mediatorMock.Object)
        {
            Number = "123456",
            User = new User { Username = "TestUser" },
            Filial = "Store A",
            Status = "Pending",
            Items = new List<Item>()
        };

        // Act
        await order.CreateAsync();

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<SaleCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Test to verify that modifying an order triggers the SaleModifiedEvent.
    /// </summary>
    [Fact]
    public async Task ModifyOrder_ShouldTriggerSaleModifiedEvent()
    {
        // Arrange
        var order = new Order(_mediatorMock.Object)
        {
            Number = "123456",
            User = new User { Username = "TestUser" },
            Filial = "Store A",
            Status = "Pending",
            Items = new List<Item>()
        };

        // Act
        await order.ModifyAsync();

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<SaleModifiedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Test to verify that cancelling an order triggers the SaleCancelledEvent.
    /// </summary>
    [Fact]
    public async Task CancelOrder_ShouldTriggerSaleCancelledEvent()
    {
        // Arrange
        var order = new Order(_mediatorMock.Object)
        {
            Number = "123456",
            User = new User { Username = "TestUser" },
            Filial = "Store A",
            Status = "Pending",
            Items = new List<Item>()
        };

        // Act
        await order.CancelAsync();

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<SaleCancelledEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Test to verify that cancelling an item triggers the ItemCancelledEvent.
    /// </summary>
    [Fact]
    public async Task CancelItem_ShouldTriggerItemCancelledEvent()
    {
        // Arrange
        var item = new Item
        {
            Product = new Product { Id = 1, Title = "Test Product" },
            Quantity = 2,
            UnitPrice = 50,
            Total = 100
        };

        var order = new Order(_mediatorMock.Object)
        {
            Number = "123456",
            User = new User { Id = 1, Username = "TestUser" },
            Total = 100,
            Filial = "Store A",
            Status = "Pending",
            Items = new List<Item> { item }
        };

        // Act
        await order.CancelItemAsync(item);

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<ItemCancelledEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}