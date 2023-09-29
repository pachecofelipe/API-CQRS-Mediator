using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Commands;

public class UpdateProductCommand : IRequest<Product>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool Active { get; set; } = true;
    public decimal Price { get; set; }
}