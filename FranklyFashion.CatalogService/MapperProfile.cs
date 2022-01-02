namespace FranklyFashion.CatalogService;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductSingleDTO>();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<Product, ProductCreatedDTO>();
    }
}
