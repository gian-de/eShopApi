using eShopApi.DTOs.ProductVariant;

namespace eShopApi.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Sku { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Brand { get; set; }
        public required long Price { get; set; }
        public required string TypeProduct { get; set; }
        public required int QtyInStock { get; set; }
        public List<ProductVariantDto> ProductVariants { get; set; } = new List<ProductVariantDto>();
        public int? TenantId { get; set; }
    }
}