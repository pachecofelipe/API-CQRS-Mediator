using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Example.API.Models;

public class Product
{
    public Guid Id { get; set; }
    
    [StringLength(80, MinimumLength = 4)]
    public string? Name { get; set; }
    
    [StringLength(200, MinimumLength = 4)]
    public string? Description { get; set; }
    
    [StringLength(80, MinimumLength = 4)]
    public string? Category { get; set; }

    public bool Enabled { get; set; } = true;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
}