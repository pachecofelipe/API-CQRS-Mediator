using CQRS.Example.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Example.API.Data;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options) => 
        options.UseSqlite("DataSource=products.db;Cache=Shared");
}