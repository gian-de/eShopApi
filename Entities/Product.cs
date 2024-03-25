using System.ComponentModel.DataAnnotations.Schema;

namespace eShopApi.Entities
{
    public class Product
    {

        [Column("product_id")]
        public int Id { get; set; }

        [Column("sku")]
        public required string Sku { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public required string Description { get; set; }

        [Column("brand")]
        public required string Brand { get; set; }

        [Column("price")]
        public required long Price { get; set; }

        [Column("type_of_product")]
        public required string TypeProduct { get; set; }

        [Column("qty_in_stock")]
        public required int QtyInStock { get; set; }

        // [Column("product_variant_id")]
        // public int ProductVariantId { get; set; }
        public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

        [Column("tenant_id")]
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}