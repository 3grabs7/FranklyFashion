namespace FranklyFashion.StockService.Data;

public class StockContext : DbContext
{
    public DbSet<StockLevel> StockLevels { get; set; }

    public StockContext(DbContextOptions options) : base(options) { }

}

