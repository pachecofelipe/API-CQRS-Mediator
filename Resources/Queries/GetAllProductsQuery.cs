using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    
}