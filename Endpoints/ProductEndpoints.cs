using CQRS.Example.API.Models;
using CQRS.Example.API.Resources.Commands;
using CQRS.Example.API.Resources.Queries;
using MediatR;

namespace CQRS.Example.API.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/");
        group.MapPost("product", CreateProduct);
        group.MapGet("product", GetProduct);
        group.MapGet("products", GetProducts);
        group.MapPut("product", UpdateProduct);
        group.MapDelete("product", DeleteProduct);
    }

    public static async Task<IResult> GetProducts(ISender mediator)
    {
        try
        {
            var command = new GetAllProductsQuery();
            var response = await mediator.Send(command);
            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> GetProduct(ISender mediator, Guid id)
    {
        try
        {
            var command = new GetProductByIdQuery { Id = id };
            var response = await mediator.Send(command);
            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> CreateProduct(ISender mediator, Product product)
    {
        try
        {
            var command = new CreateProductCommand
            {
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Active = product.Enabled,
            };
            var response = await mediator.Send(command);
            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
    
    public static async Task<IResult> UpdateProduct(ISender sender, Product product)
    {
        try
        {
            var command = new UpdateProductCommand
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Active = product.Enabled,
            };
            var response = await sender.Send(command);
            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
    
    public static async Task<IResult> DeleteProduct(ISender sender, Guid id)
    {
        try
        {
            var command = new DeleteProductCommand { Id = id };
            var response = await sender.Send(command);
            return response is not null ? Results.Ok(response) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}