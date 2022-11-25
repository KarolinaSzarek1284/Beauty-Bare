using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeautyBareContext _context;

        public ProductRepository(BeautyBareContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductSubcategory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductSubcategory)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductCategory>> GetProductsCategoryAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductSubcategory>> GetProductsSubcategoryAsync()
        {
            return await _context.ProductSubcategories.ToListAsync();
        }
    }
}
