using CQRS.Example.API.Data;
using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly ProductDbContext _context;

    public DeleteProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);
        
        if (product is null)
        {
            return default;
        }
            
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}