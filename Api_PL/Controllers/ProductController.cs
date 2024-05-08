



namespace Api_PL.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> genericRepository;
        private readonly IGenericRepository<Brand> brandrepo;
        private readonly IGenericRepository<Category> categoryRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> genericRepository,IGenericRepository<Brand> brandrepo,IGenericRepository<Category> categoryRepo,IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.brandrepo = brandrepo;
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<Pagination<ProductDto>>> GetAllProducts([FromQuery] ProductSpecParms SpecParms)
        {
            var spec = new ProductWithBrandAndTypeSpecification(SpecParms);
            var products = await genericRepository.GetAllWithApecAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            var countspec = new ProductWithFilterationforCountSpec(SpecParms);
            var count = await genericRepository.GetCountAsyncWithSpec(countspec);
            return Ok(new Pagination<ProductDto>(SpecParms.PageIdex, SpecParms.Size, count, data));
        }
        [ProducesResponseType(typeof(ProductDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await genericRepository.GetbyIdSpecAsync(spec);
            if (product == null)
                return NotFound(new ApiResponse(404));    
            var p=mapper.Map<Product,ProductDto>(product);
            return Ok(p);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brand =await brandrepo.GetAllAsync();
            return Ok(brand);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<Category>>> Getcategory()
        {
            var cat = categoryRepo.GetAllAsync();
            return Ok(cat);
        }
    }
}
