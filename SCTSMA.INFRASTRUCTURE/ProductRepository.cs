using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Product;
using SCTSMA.UTILS;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.INFRASTRUCTURE
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbService _dbService;
        public ProductRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResult<bool>> CreateProduct(ProductModel productModel)
        {
            using (var transaction = await _dbService.BeginTransaction())
            {
                try
                {
                    var productResult = await _dbService.EditDataWithId(
                    "INSERT INTO products (product_name, product_image, created_at, product_description, status_id, product_price) VALUES (@ProductName, @ProductImage, @CreatedAt, @ProductDescription, @StatusId, @ProductPrice) RETURNING product_id",
                    new
                    {
                        ProductName = productModel.product_name,
                        ProductImage = productModel.product_image,
                        CreatedAt = productModel.created_at,
                        ProductDescription = productModel.product_description,
                        StatusId = productModel.status_id,
                        ProductPrice = productModel.product_price
                    },
                    transaction
                );


                    if (!productResult.succeeded)
                    {
                        await _dbService.RollbackTransaction(transaction);
                        return Result<bool>.Failure("Failed to create product.");
                    }

                    int productId = productResult.data;

                    var sellerResult = await _dbService.EditData(
                        "INSERT INTO product_sellers (product_id, seller_phone) VALUES (@ProductId, @SellerPhone)",
                        new { ProductId = productId, SellerPhone = productModel.seller_phone },
                        transaction
                    );

                    if (!sellerResult.succeeded)
                    {
                        await _dbService.RollbackTransaction(transaction);
                        return Result<bool>.Failure("Failed to create product seller.");
                    }

                    await _dbService.CommitTransaction(transaction);
                    return Result<bool>.Success(true);
                }
                catch
                {
                    await _dbService.RollbackTransaction(transaction);
                    return Result<bool>.Failure("An error occurred while creating the product.");
                }
            }
        }

        public async Task<IResult<List<ProductModel>>> GetAllProducts()
        {
            var result = await _dbService.GetAll<ProductModel>(
                @"SELECT p.product_id, p.product_name, ps.seller_phone, p.product_image, p.created_at, p.product_description, p.status_id, p.product_price 
                  FROM products p 
                  JOIN product_sellers ps ON p.product_id = ps.product_id",
                new { }
            );

            return result;
        }

        public async Task<IResult<ProductModel>> GetProductById(int productId)
        {
            var result = await _dbService.GetAsync<ProductModel>(
                @"SELECT p.product_id, p.product_name, ps.seller_phone, p.product_image, p.created_at, p.product_description, p.status_id, p.product_price  
                  FROM products p 
                  JOIN product_sellers ps ON p.product_id = ps.product_id 
                  WHERE p.product_id = @ProductId",
                new { ProductId = productId }
            );

            return result;
        }

        public async Task<IResult<List<ProductModel>>> GetProductsBySellerPhone(string seller_phone)
        {
            var result = await _dbService.GetAll<ProductModel>(
                @"SELECT p.product_id, p.product_name, ps.seller_phone, p.product_image, p.created_at, p.product_description, p.status_id, p.product_price  
                  FROM products p 
                  JOIN product_sellers ps ON p.product_id = ps.product_id 
                  WHERE ps.seller_phone = @SellerPhone",
                new { SellerPhone = seller_phone }
            );

            return result;
        }

        public async Task<IResult<bool>> UpdateProduct(ProductModel productModel)
        {
            var result = await _dbService.EditData(
                @"UPDATE products 
                  SET product_name = @ProductName, product_image = @ProductImage, created_at = @CreatedAt, 
                      product_description = @ProductDescription, status_id = @StatusId, product_price = @ProductPrice 
                  WHERE product_id = @ProductId",
                new
                {
                    ProductId = productModel.product_id,
                    ProductName = productModel.product_name,
                    ProductImage = productModel.product_image,
                    CreatedAt = productModel.created_at,
                    ProductDescription = productModel.product_description,
                    StatusId = productModel.status_id,
                    ProductPrice = productModel.product_price
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to update product.");
        }
    }
}
