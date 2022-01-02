
namespace FranklyFashion.BasketService.Models;
public class BasketDTO
{
    public string Identifier { get; set; }
    public ICollection<BasketItemDTO> BasketItems { get; set; }

}

