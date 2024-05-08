
namespace Api_PL.Helpers
{
    public class Pagination<T>
    {
        public Pagination(int pageIdex, int size, int count, IReadOnlyList<ProductDto> data)
        {
            PageIdex = pageIdex;
            Size = size;
            Data = data;
            this.Count = count;
        }

        public int PageIndex {  get; set; }
        public int PageSize {  get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Date { get; set; }
        public int PageIdex { get; }
        public int Size { get; }
        public IEnumerable<ProductDto> Data { get; }
    }
}
