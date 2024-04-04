using System.ComponentModel.DataAnnotations;
using eShopApi.DTOs.ProductVariant;

namespace eShopApi.DTOs.Product
{
    public class UpdateProductRequestDto()
    {
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public long? Price { get; set; }
        public string? TypeProduct { get; set; }
        public int? QtyInStock { get; set; }
        public List<UpdateProductVariantDto?> ProductVariants { get; set; }
    }
}

// use to test PATCH endpoint

// {
//   "name": "testing123",
//   "sku": null,
//   "description": null,
//   "brand": null,
//   "price": null,
//   "typeProduct": null,
//   "qtyInStock": null,
//   "productVariants": []
// }
