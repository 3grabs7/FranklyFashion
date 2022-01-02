

using FranklyFashion.OrderService.Models;
using System.Text.Json;

namespace FranklyFashion.OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderContext _context;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderController(OrderContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost]
    public async Task<ActionResult<OrderCreatedDTO>> Order(OrderCreateDTO order)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var httpResponse = await httpClient.GetAsync($"http://localhost:5108/api/basket/{order.Identifier}");

        var content = await httpResponse.Content.ReadAsStringAsync();

        var basket = JsonSerializer.Deserialize<BasketDTO>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (basket?.Identifier == null)
            return NotFound();
        if (basket.BasketItems == null)
            return BadRequest();

        var newOrder = await _context.Orders.AddAsync(
            new Order
            {
                Customer = order.Customer,
                OrderLines = basket.BasketItems.Select(b => _mapper.Map<OrderLine>(b)).ToList()
            });

        await _context.SaveChangesAsync();

        return Created("", new OrderCreatedDTO { OrderId = newOrder.Entity.Id, });
    }


}
