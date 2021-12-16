namespace FranklyFashion.StockService.Models;
public class StockLevel
{
    [Key]
    public string ArticleNumber { get; set; }
    public int Stock { get; set; }
}
