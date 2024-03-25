using eShopApi.Entities;

namespace eShopApi.Data
{
    public static class DbInitializer
    {

        public static void Initialize(StoreDbContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Sku = "0001",
                    Name = "Short sleeve T-shirt product777",
                    Description = "Description of a t-shirt",
                    Brand = "Generic",
                    Price = 25,
                    TypeProduct = "t-shirt",
                    QtyInStock= 180,
                    TenantId = 1,
                    ProductVariants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Color = "white",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://i5.walmartimages.com/asr/4f899086-2a8d-46f6-950a-c03988fe6e7b_1.403fde7b7d097f03138351949c81a00f.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF&odnDynImageQuality=85"
                                }
                            },
                        },
                        new ProductVariant
                        {
                            Color = "blue",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://i5.walmartimages.com/asr/c0123ee7-fc33-459d-b13e-0e73f0f2b934_1.f56b2fe4cd22a721d249c4beb6767c76.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF&odnDynImageQuality=85"
                                }
                            }
                        },
                        new ProductVariant
                        {
                            Color = "yellow",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://i5.walmartimages.com/asr/d347ceba-9599-4356-b71d-4f80d9eadc29_1.d65f72e253fbd9206885b83c4dd6171a.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF&odnDynImageQuality=85"
                                }
                            }
                        },
                        new ProductVariant
                        {
                            Color = "red",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://i5.walmartimages.com/asr/a0529764-652b-4b81-b0b9-f388cc9021f1_1.443fe06af9fdcf0f4c306075a0bb9bfd.jpeg?odnHeight=711&odnWidth=711&odnBg=FFFFFF&odnDynImageQuality=85"
                                }
                            }
                        }
                    }
                },
                new Product
                {
                    Sku = "000002",
                    Name = "long sleeve shirt product77",
                    Description = "long sleeve shirt, that is perfect for anyone",
                    Brand = "No name brand",
                    Price = 35,
                    TypeProduct = "long-sleeve",
                    QtyInStock= 250,
                    TenantId= 2,
                    ProductVariants =
                    [
                        new ProductVariant
                        {
                            Color = "black",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://m.media-amazon.com/images/I/61+mX-sZsXS._AC_UX679_.jpg"
                                },
                                new ProductImage
                                {
                                    ImageUrl = "https://m.media-amazon.com/images/I/41TYP-hfpSS._AC_UX679_.jpg"
                                }
                            }
                        },
                        new ProductVariant
                        {
                            Color = "orange",
                            ProductImages = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    ImageUrl = "https://i5.walmartimages.com/asr/795ffd7d-9f04-4920-b5e1-430badecbb81_1.2fd29a2c7b1a7ee43c0dae8b460e9c6a.jpeg?odnHeight=711&odnWidth=711&odnBg=FFFFFF&odnDynImageQuality=85"
                                }
                            }
                        },
                    ]
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}