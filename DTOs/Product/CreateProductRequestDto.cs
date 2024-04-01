using eShopApi.DTOs.ProductImage;
using eShopApi.DTOs.ProductVariant;

namespace eShopApi.DTOs.Product
{
    public class CreateProductRequestDto
    {
        public required string Sku { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Brand { get; set; }
        public required long Price { get; set; }
        public required string TypeProduct { get; set; }
        public required int QtyInStock { get; set; }
        public List<ProductVariantDto> ProductVariants { get; set; } = new List<ProductVariantDto>();

        // method to add variants as well
        public void AddVariant(ProductVariantDto variant)
        {
            ProductVariants.Add(variant);
        }
    }
}