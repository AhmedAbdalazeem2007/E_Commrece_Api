namespace Api_PL.Dtos
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "")]
        public decimal Price { get; set; }
        public string PicturUrl { get; set; }
        public string Barnd { get; set; }
        public string Type { get; set; }
    }
}
