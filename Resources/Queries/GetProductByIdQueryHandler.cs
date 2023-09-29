using CQRS.Example.API.Data;
using CQRS.Example.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Example.API.Resources.Queries;

public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ProductDbContext _context;

    public GetProductByIdQueryHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}