using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Commands;

public class DeleteProductCommand : IRequest<Product>
{
    public Guid Id { get; set; }
}