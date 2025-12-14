using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalog.API.Context
{
    public class CatalogDbContext: DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
