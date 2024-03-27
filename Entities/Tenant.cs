using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eShopApi.Entities
{
    [Index(nameof(UniqueAddress), IsUnique = true)]
    public class Tenant
    {
        [Column("tenant_id")]
        public int Id { get; set; }

        [Column("tenant_name")]
        public required string Name { get; set; }

        [Column("unique_address")]
        public required string UniqueAddress { get; set; }
        public required List<Product> Products { get; set; }
    }
}
