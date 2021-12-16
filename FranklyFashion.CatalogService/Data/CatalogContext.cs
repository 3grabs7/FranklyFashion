namespace FranklyFashion.CatalogService.Data;
public class CatalogContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public CatalogContext(DbContextOptions options) : base(options) { }
}
