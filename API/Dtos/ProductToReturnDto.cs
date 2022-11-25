using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contraindications { get; set; }
        public string Apllying { get; set; }
        public int Capacity { get; set; }
        public bool IsVegan { get; set; }
        public string Country { get; set; }
        public bool InUse { get; set; }
        public string PictureUrl { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubcategory { get; set; }
    }
}
