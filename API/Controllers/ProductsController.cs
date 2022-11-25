using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using API.Helpers;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepo;
        private readonly IGenericRepository<ProductSubcategory> _productSubcategoryRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> _productRepo,
            IGenericRepository<ProductBrand> _productBrandRepo, IGenericRepository<ProductCategory> _productCategoryRepo,
            IGenericRepository<ProductSubcategory> _productSubcategoryRepo, IMapper mapper)
        {
            this._productRepo = _productRepo;
            this._productBrandRepo = _productBrandRepo;
            this._productCategoryRepo = _productCategoryRepo;
            this._productSubcategoryRepo = _productSubcategoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(productParams);

            var countSpec = new ProductWithFilterForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);

            var products = await _productRepo.ListAsync(spec);  

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetProductCategories()
        {
            return Ok(await _productCategoryRepo.ListAllAsync());
        }
        [HttpGet("subcategories")]
        public async Task<ActionResult<IReadOnlyList<ProductSubcategory>>> GetProductSubcategories()
        {
            return Ok(await _productSubcategoryRepo.ListAllAsync());
        }
    }
}
