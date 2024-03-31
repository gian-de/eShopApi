using eShopApi.DTOs.ProductImage;

namespace eShopApi.DTOs.ProductVariant
{
    public class ProductVariantDto
    {
        // add id for unique key to map a ui dropdown on frontend for example
        public int Id { get; set; }
        public required string Color { get; set; }
        public int ProductId { get; set; }
        public List<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
    }
}