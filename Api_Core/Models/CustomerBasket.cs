
namespace Api_Core.Models
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public CustomerBasket(string id)
        {
            this.Id = id;
        }
    }
}
