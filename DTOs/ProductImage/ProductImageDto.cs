using eShopApi.DTOs.ProductVariant;

namespace eShopApi.DTOs.ProductImage
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }

    }
}