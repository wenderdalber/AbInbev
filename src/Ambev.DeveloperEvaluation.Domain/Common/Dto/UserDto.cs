using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Common.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public AddressDto Address { get; set; }
}

public class AddressDto
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Zipcode { get; set; }
    public GeolocationDto Geolocation { get; set; }
}

public class GeolocationDto
{
    public double Lat { get; set; }
    public double Long { get; set; }
}

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}

public class RatingDto
{
    public double Rate { get; set; }
    public int Count { get; set; }
}

public class OrderDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public UserDto User { get; set; }
    public decimal Total { get; set; }
    public List<ItemDto> Items { get; set; }
}

public class ItemDto
{
    public int Id { get; set; }
    public ProductDto Product { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
}
