
namespace Api_PL.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
              .ForMember(p => p.Id, o => o.MapFrom(p => p.Id))
              .ForMember(p => p.Name, o => o.MapFrom(o => o.Name))
              .ForMember(p => p.Price, o => o.MapFrom(p => p.Price))
              .ForMember(p => p.Brand, o => o.MapFrom(p => p.Brand.Name))
              .ForMember(p => p.Category, o => o.MapFrom(p => p.Category.Name))
              .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductPictureUrlSolver>());
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
    }
    }
}
