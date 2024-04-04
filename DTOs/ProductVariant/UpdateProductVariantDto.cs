using eShopApi.DTOs.ProductImage;

namespace eShopApi.DTOs.ProductVariant
{
    public class UpdateProductVariantDto
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public int ProductId { get; set; }
        public List<ProductImageDto>? ProductImages { get; set; } = new List<ProductImageDto>();
    }
}