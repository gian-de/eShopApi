using eShopApi.Data;
using eShopApi.DTOs.Product;
using eShopApi.Entities;
using eShopApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShopApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;
        public ProductsController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products
                                            .Include(p => p.ProductVariants)
                                            .ThenInclude(pv => pv.ProductImages)
                                            .ToListAsync();

            var productsDto = products.Select(p => p.ToProductDto());

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products
                                            .Include(p => p.ProductVariants)
                                            .ThenInclude(pv => pv.ProductImages)
                                            .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto productRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Check if at least one image URL is provided
            if (productRequest.ProductVariants == null || productRequest.ProductVariants.Count == 0)
            {
                ModelState.AddModelError("ProductVariants", "At least one product variant is required.");
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Sku = productRequest.Sku,
                Name = productRequest.Name,
                Description = productRequest.Description,
                Brand = productRequest.Brand,
                Price = productRequest.Price,
                TypeProduct = productRequest.TypeProduct,
                QtyInStock = productRequest.QtyInStock,
            };
            // Attach variant(s) to CreateProductRequestDto
            foreach (var prodVariant in productRequest.ProductVariants)
            {
                var variant = new ProductVariant
                {
                    Color = prodVariant.Color
                };
                // Attach images to the variant
                // Check if ProductImages has at least one element
                if (prodVariant.ProductImages != null && prodVariant.ProductImages.Count > 0)
                {
                    foreach (var prodImage in prodVariant.ProductImages)
                    {
                        if (!string.IsNullOrEmpty(prodImage.ImageUrl))
                        {
                            var image = new ProductImage
                            {
                                ImageUrl = prodImage.ImageUrl
                            };
                            variant.ProductImages.Add(image);
                        }
                        else
                        {
                            return BadRequest("Image URL cannot be empty for each product variant.");
                        }
                    }
                }
                else
                {
                    return BadRequest("At least one image URL must be provided for each product variant.");
                }

                product.ProductVariants.Add(variant);
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}

// {
//   "sku": "test1",
//   "name": "test1",
//   "description": "test1",
//   "brand": "test1",
//   "price": 10,
//   "typeProduct": "test1",
//   "qtyInStock": 10,
//   "productVariants": [
//     {

//       "color": "test1",
//       "productImages": [
//         {

//           "imageUrl": "test1"
//         }
//       ]
//     }
//   ]
// }

// {
//   "sku": "test1",
//   "name": "test1",
//   "description": "test1",
//   "brand": "test1",
//   "price": 10,
//   "typeProduct": "test1",
//   "qtyInStock": 10,
//   "productVariants": [
//     {

//       "color": "test1",
//       "productImages": [
//         {

//           "imageUrl": "test1111",
//         },
// {

//           "imageUrl": "test2222",
//         },
// {

//           "imageUrl": "test333",
//         }
//       ]
//     }
//   ]
// }