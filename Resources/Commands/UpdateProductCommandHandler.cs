using CQRS.Example.API.Data;
using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly ProductDbContext _context;

    public UpdateProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

        if (product is null)
        {
            return default;
        }
        
        product.Name = request.Name;
        product.Description = request.Description;
        product.Category = request.Category;
        product.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}