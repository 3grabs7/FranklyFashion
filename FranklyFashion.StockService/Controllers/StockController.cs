namespace FranklyFashion.StockService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockContext _context;
    private readonly IMapper _mapper;
    public StockController(StockContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPut("{articleNumber}")]
    public async Task<IActionResult> UpdateStockLevel(string articleNumber, StockLevelPutDTO stockLevelDTO)
    {
        var stockLevel = await _context.StockLevels
            .FirstOrDefaultAsync(s => s.ArticleNumber == articleNumber);

        if (stockLevel == null)
            await _context.AddAsync(
                 _mapper.Map<StockLevel>(stockLevelDTO)
                 );
        else
            stockLevel.Stock = stockLevelDTO.Stock;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet]
    public ActionResult<IEnumerable<StockLevelListDTO>> GetAll()
    {
        var stockLevels = _context.StockLevels
            .Select(s => _mapper.Map<StockLevelListDTO>(s));

        if (stockLevels.Any())
            return Ok(stockLevels);

        return NoContent();
    }


}

