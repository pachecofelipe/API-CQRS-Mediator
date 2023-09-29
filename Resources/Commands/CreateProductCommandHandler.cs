using CQRS.Example.API.Data;
using CQRS.Example.API.Models;
using MediatR;

namespace CQRS.Example.API.Resources.Commands;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductDbContext _context;

    public CreateProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Category = request.Category,
            Description = request.Description,
            Price = request.Price
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
}