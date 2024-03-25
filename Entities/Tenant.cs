using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace eShopApi.Entities
{
    public class Tenant
    {
        [Column("tenant_id")]
        public int Id { get; set; }

        [Column("tenant_name")]
        public required string Name { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public required List<Product> Products { get; set; }
    }

}