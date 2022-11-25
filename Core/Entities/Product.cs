namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contraindications { get; set; }
        public string Apllying { get; set; }
        public int Capacity { get; set; }
        public bool IsVegan { get; set; }
        public string Country { get; set; }
        public bool InUse { get; set; }
        public string PictureUrl { get; set; }
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductSubcategoryId { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
    }
}
