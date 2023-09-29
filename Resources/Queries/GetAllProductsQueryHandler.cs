using CQRS.Example.API.Data;
using CQRS.Example.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Example.API.Resources.Queries;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly ProductDbContext _context;

    public GetAllProductsQueryHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken: cancellationToken);
    }
}