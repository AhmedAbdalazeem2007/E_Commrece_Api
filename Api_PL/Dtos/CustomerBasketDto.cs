namespace Api_PL.Dtos
{
    public class CustomerBasketDto
    {
        public int Id { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
