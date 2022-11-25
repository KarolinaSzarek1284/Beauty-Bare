using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BeautyBareContextSeed
    {
        public static async Task SeedAsync(BeautyBareContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProductCategories.Any())
                {
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/category.json");
                    var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                    foreach (var item in categories)
                    {
                        context.ProductCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProductSubcategories.Any())
                {
                    var subcategoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/subcategory.json");
                    var subcategories = JsonSerializer.Deserialize<List<ProductSubcategory>>(subcategoriesData);

                    foreach (var item in subcategories)
                    {
                        context.ProductSubcategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BeautyBareContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
