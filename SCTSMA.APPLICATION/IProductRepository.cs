using SCTSMA.DOMAIN.Models.Product;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IProductRepository
    {
        Task<IResult<bool>> CreateProduct(ProductModel productModel);
        Task<IResult<bool>> UpdateProduct(ProductModel productModel);
        Task<IResult<List<ProductModel>>> GetAllProducts();
        Task<IResult<List<ProductModel>>> GetProductsBySellerPhone(string seller_phone);
        Task<IResult<ProductModel>> GetProductById(int productId);
    }
}
