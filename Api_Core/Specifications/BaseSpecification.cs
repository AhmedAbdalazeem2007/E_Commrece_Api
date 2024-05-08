


namespace Api_Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Createria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> expression)
        {
            Createria = expression;
        }

        public void AddOrderby(Expression<Func<T, object>> ordebyasc)
        {
            this.OrderBy = ordebyasc;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderbydesc)
        {
            this.OrderByDesc = orderbydesc;
        }
        public int Take { get; set; }
        public int Skip { get; set; } 
        public bool IsPaginationEnable { get; set; }
        public void ApplyPigination(int skip,int take)
        {
            IsPaginationEnable = true;
            this.Take = take;
            this.Skip = skip;
        } 

    }
}
