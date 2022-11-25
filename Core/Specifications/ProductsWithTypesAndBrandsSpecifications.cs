using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecifications(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.CategoryId.HasValue || x.ProductCategoryId == productParams.CategoryId)
            )
        {
            AddInclude(x => x.ProductCategory);
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductSubcategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "capacityAsc":
                        AddOrderBy(c => c.Capacity);
                        break;
                    case "capacityDesc":
                        AddOrderByDescending(c => c.Capacity);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductCategory);
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductSubcategory);
        }
    }
}
