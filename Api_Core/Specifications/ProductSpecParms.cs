
namespace Api_Core.Specifications
{
    public class ProductSpecParms
    {
        const int MaxPagesize = 100;
        private int pagesize = 100;
        public string Search {  get; set; }
        public int Size
        {
            get { return pagesize; }
            set { pagesize = value > MaxPagesize ? MaxPagesize : value; }
        }
        public int PageIdex { get; set; } = 1;
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
