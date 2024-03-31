using eShopApi.DTOs.Product;
using eShopApi.DTOs.ProductImage;
using eShopApi.DTOs.ProductVariant;
using eShopApi.Entities;

namespace eShopApi.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Sku = productModel.Sku,
                Name = productModel.Name,
                Description = productModel.Description,
                Brand = productModel.Brand,
                Price = productModel.Price,
                TypeProduct = productModel.TypeProduct,
                QtyInStock = productModel.QtyInStock,
                ProductVariants = productModel.ProductVariants
                    .Select(pv => new ProductVariantDto
                    {
                        // Map properties of ProductVariantDto from ProductVariant entity
                        Id = pv.Id,
                        Color = pv.Color,
                        ProductId = pv.ProductId,
                        ProductImages = pv.ProductImages
                            .Select(pi => new ProductImageDto
                            {
                                // Map properties of ProductImageDto from ProductImage entity
                                Id = pi.Id,
                                ImageUrl = pi.ImageUrl,
                            })
                            .ToList()
                    })
                    .ToList()
            };
        }
    }
}