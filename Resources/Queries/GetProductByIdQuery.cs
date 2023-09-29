using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; set; }
}