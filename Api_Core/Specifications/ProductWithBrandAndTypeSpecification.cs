


namespace Api_Core.Specifications
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification(ProductSpecParms productSpecParms)
        : base(p =>
             (!productSpecParms.BrandId.HasValue || p.ProductBrandId == productSpecParms.BrandId) &&
             (!productSpecParms.TypeId.HasValue || p.ProductTypeId == productSpecParms.TypeId) &&
        (string.IsNullOrEmpty(productSpecParms.Search) || p.Name.ToLower().Contains(productSpecParms.Search.ToLower()))
            )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
            AddOrderby(p => p.Name);
            if (!string.IsNullOrEmpty(productSpecParms.Sort))
            {
                switch (productSpecParms.Sort)
                {
                    case "priceAsc":
                        AddOrderby(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderby(p => p.Name);
                        break;
                }
            }
            ApplyPigination(productSpecParms.Size * (productSpecParms.PageIdex - 1), productSpecParms.Size);

        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
