namespace FranklyFashion.BasketService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IDistributedCache _cache;
    public BasketController(IDistributedCache cache)
    {
        _cache = cache;
    }

    [HttpGet("{basketId}")]
    public async Task<ActionResult<BasketDTO>> GetBasket(string basketId)
    {
        var basket = await _cache.GetStringAsync(basketId);
        if (basket == null)
            return NotFound();

        var result = JsonSerializer.Deserialize<BasketDTO>(basket);

        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<BasketDTO>> UpdateBasket(BasketDTO basket)
    {
        await _cache.SetStringAsync(basket.Identifier, JsonSerializer.Serialize(basket));
        return await GetBasket(basket.Identifier);
    }

}
