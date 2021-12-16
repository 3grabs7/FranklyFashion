namespace FranklyFashion.CatalogService;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductListDTO>();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<Product, ProductCreatedDTO>();
    }
}
