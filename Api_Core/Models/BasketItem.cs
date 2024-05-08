

namespace Api_Core.Models
{
    public class BasketItem:BaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public string PicturUrl { get; set; }
        public string Barnd {  get; set; }
        public string Type { get; set; }

    }
}
