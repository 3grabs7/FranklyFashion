using FranklyFashion.OrderService.Models;

namespace FranklyFashion.OrderService;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<BasketDTO, Order>()
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.BasketItems));
        CreateMap<BasketItemDTO, OrderLine>();
    }
}
