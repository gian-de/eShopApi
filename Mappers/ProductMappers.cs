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

        public static Product UpdateProductFromDto(this Product product, UpdateProductRequestDto productDto)
        {
            if (productDto.Sku != null)
            {
                product.Sku = productDto.Sku;
            }

            if (productDto.Name != null)
            {
                product.Name = productDto.Name;
            }

            if (productDto.Description != null)
            {
                product.Description = productDto.Description;
            }

            if (productDto.Brand != null)
            {
                product.Brand = productDto.Brand;
            }

            if (productDto.Price != null)
            {
                product.Price = (long)productDto.Price;
            }

            if (productDto.TypeProduct != null)
            {
                product.TypeProduct = productDto.TypeProduct;
            }

            if (productDto.QtyInStock != null)
            {
                product.QtyInStock = (int)productDto.QtyInStock;
            }

            if (productDto.ProductVariants != null)
            {
                foreach (var variantDto in productDto.ProductVariants)
                {
                    var currentVariant = product.ProductVariants.FirstOrDefault(v => v.Id == variantDto.Id);
                    // var currentVariant = product.ProductVariants.FirstOrDefault(v => v.Color == variantDto.Color);
                    if (currentVariant != null)
                    {
                        currentVariant.Color = variantDto.Color ?? currentVariant.Color;

                        if (variantDto.ProductImages != null)
                        {
                            foreach (var imageDto in variantDto.ProductImages)
                            {
                                var currentImage = currentVariant.ProductImages.FirstOrDefault(i => i.Id == imageDto.Id)
                                    ?? new ProductImage();

                                currentImage.ImageUrl = imageDto.ImageUrl ?? currentImage.ImageUrl;

                                currentVariant.ProductImages.Add(currentImage);
                            }
                        }
                    }
                }
            }
            return product;
        }
    }
}