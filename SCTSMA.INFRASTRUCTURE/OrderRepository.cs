using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Order;
using SCTSMA.UTILS;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.INFRASTRUCTURE
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbService _dbService;
        public OrderRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResult<bool>> CreateOrder(OrderRequestModel orderRequestModel)
        {
            var result = await _dbService.EditData(
                @"INSERT INTO orders (seller_phone, customer_phone, product_id, quantity, status_id) 
                  VALUES (@SellerPhone, @CustomerPhone, @ProductId, @Quantity, @StatusId)",
                new
                {
                    SellerPhone = orderRequestModel.seller_phone,
                    CustomerPhone = orderRequestModel.customer_phone,
                    ProductId = orderRequestModel.product_id,
                    Quantity = orderRequestModel.quantity,
                    StatusId = orderRequestModel.status_id
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to create order.");
        }

        public async Task<IResult<bool>> DeleteOrder(OrderRequestModel orderRequestModel)
        {
            var result = await _dbService.EditData(
                "DELETE FROM orders WHERE order_id = @OrderId",
                new { OrderId = orderRequestModel.order_id }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to delete order.");
        }

        public async Task<IResult<List<OrderResponseModel>>> GetAllOrders()
        {
            var result = await _dbService.GetAll<OrderResponseModel>(
                @"SELECT o.order_id, o.seller_phone, o.customer_phone, 
                         s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         c.first_name AS customer_first_name, c.last_name AS customer_last_name, 
                         o.product_id, p.product_name, o.quantity, o.status_id, o.created_at, o.expires_at
                  FROM orders o
                  JOIN users s ON o.seller_phone = s.phone_number
                  JOIN users c ON o.customer_phone = c.phone_number
                  JOIN products p ON o.product_id = p.product_id", new { }
            );

            return result;
        }

        public async Task<IResult<List<OrderResponseModel>>> GetOrdersByCustomerPhone(string customer_phone)
        {
            var result = await _dbService.GetAll<OrderResponseModel>(
                @"SELECT o.order_id, o.seller_phone, o.customer_phone, 
                         s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         c.first_name AS customer_first_name, c.last_name AS customer_last_name, 
                         o.product_id, p.product_name, o.quantity, o.status_id, o.created_at, o.expires_at
                  FROM orders o
                  JOIN users s ON o.seller_phone = s.phone_number
                  JOIN users c ON o.customer_phone = c.phone_number
                  JOIN products p ON o.product_id = p.product_id
                  WHERE o.customer_phone = @CustomerPhone",
                new { CustomerPhone = customer_phone }
            );

            return result;
        }

        public async Task<IResult<List<OrderResponseModel>>> GetOrdersBySellerPhone(string seller_phone)
        {
            var result = await _dbService.GetAll<OrderResponseModel>(
                @"SELECT o.order_id, o.seller_phone, o.customer_phone, 
                         s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         c.first_name AS customer_first_name, c.last_name AS customer_last_name, 
                         o.product_id, p.product_name, o.quantity, o.status_id, o.created_at, o.expires_at
                  FROM orders o
                  JOIN users s ON o.seller_phone = s.phone_number
                  JOIN users c ON o.customer_phone = c.phone_number
                  JOIN products p ON o.product_id = p.product_id
                  WHERE o.seller_phone = @SellerPhone",
                new { SellerPhone = seller_phone }
            );

            return result;
        }
    }
}
