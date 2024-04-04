using System.ComponentModel.DataAnnotations.Schema;

namespace eShopApi.Entities
{
    public class ProductImage
    {

        [Column("image_id")]
        public int Id { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }

        [Column("product_variant_id")]
        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        public ProductImage()
        {
            ImageUrl = ""; // Initialize with an empty string or to satisfy the UpdateProductFromDto inside mappers
        }

    }
}