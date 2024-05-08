
namespace Api_PL.Controllers
{

    public class BasketsController : BaseApiController
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketsController(IBasketRepository basketRepository,IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await basketRepository.GetBasketAsync(id);
            return basket ?? new CustomerBasket(id);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto customerBasket)
        {
            var mapbasket=mapper.Map<CustomerBasketDto,CustomerBasket>(customerBasket);
            var basket = await basketRepository.UpdateBasketAsync(mapbasket);
            if (basket != null)
                return BadRequest(new ApiResponse(400));
            return basket;
        }

        [HttpDelete]
        public async Task DeleteBasket(string basketid)
        {
            await basketRepository.DeleteBaskeyAsync(basketid);
        }
    }
}
