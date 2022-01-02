namespace FranklyFashion.CatalogService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly CatalogContext _context;
    private readonly IMapper _mapper;

    public CatalogController(CatalogContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public IEnumerable<ProductSingleDTO> GetAll()
    {
        var products = _context.Products;
        return products.Select(s => _mapper.Map<ProductSingleDTO>(s));
    }

    [HttpGet("{productId}")]
    public ProductSingleDTO Get(int productId)
    {
        var product = _context.Products.Single(p => p.Id == productId);
        return _mapper.Map<ProductSingleDTO>(product);
    }

    [HttpPost]
    public async Task<ProductCreatedDTO> Post(ProductCreateDTO productCreateDto)
    {
        var createdProduct = await _context.AddAsync(_mapper.Map<Product>(productCreateDto));

        createdProduct.Entity.UrlSlug = Regex.Replace(
            productCreateDto.Name, @"\s|[-]", m => m.Value == " " ? "-" : ""
            );

        await _context.SaveChangesAsync();

        return _mapper.Map<ProductCreatedDTO>(createdProduct.Entity);
    }


    //// using a dictionary when parsing product name
    //// makes changing parsing approach more manageble
    //public async Task<ProductCreatedDTO> Post2(ProductCreateDTO productCreateDto)
    //{
    //    Dictionary<string, string> productNameParseDictionary = new()
    //    {
    //        ["-"] = "",
    //        [" "] = "-",
    //    };

    //    var createdProduct = await _context.AddAsync(_mapper.Map<Product>(productCreateDto));

    //    createdProduct.Entity.UrlSlug = Regex.Replace(
    //        productCreateDto.Name, $"\\s|[{String.Concat(productNameParseDictionary.Keys)}]",
    //        m => productNameParseDictionary[m.Value]
    //        );

    //    await _context.SaveChangesAsync();

    //    return _mapper.Map<ProductCreatedDTO>(createdProduct.Entity);
    //}

}






