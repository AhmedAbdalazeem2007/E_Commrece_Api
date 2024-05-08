
namespace Api_Core.Specifications
{
    public class ProductWithFilterationforCountSpec:BaseSpecification<Product>
    {
        public ProductWithFilterationforCountSpec(ProductSpecParms productSpecParms)
               : base(p =>
               (!productSpecParms.BrandId.HasValue || p.ProductBrandId == productSpecParms.BrandId) &&
             (!productSpecParms.BrandId.HasValue || p.ProductBrandId == productSpecParms.BrandId) &&
             (!productSpecParms.TypeId.HasValue || p.ProductTypeId == productSpecParms.TypeId)
            )
        {

        }

    }
}
