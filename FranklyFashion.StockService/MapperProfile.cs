namespace FranklyFashion.StockService;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<StockLevel, StockLevelListDTO>();
        CreateMap<StockLevelPutDTO, StockLevel>();

    }
}

