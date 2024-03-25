using System.ComponentModel.DataAnnotations.Schema;

namespace eShopApi.Entities
{
    public class ProductVariant
    {

        [Column("variant_id")]
        public int Id { get; set; }

        [Column("color")]
        public required string Color { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    }
}