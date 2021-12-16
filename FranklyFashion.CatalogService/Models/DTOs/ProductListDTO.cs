namespace FranklyFashion.CatalogService.Models;
public class ProductListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Price { get; set; }
    public string UrlSlug { get; set; }
}

