using SCTSMA.DOMAIN.Models.Order;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IOrderRepository
    {
        Task<IResult<List<OrderResponseModel>>> GetAllOrders();
        Task<IResult<bool>> CreateOrder(OrderRequestModel orderRequestModel);
        Task<IResult<List<OrderResponseModel>>> GetOrdersBySellerPhone(string seller_phone);
        Task<IResult<List<OrderResponseModel>>> GetOrdersByCustomerPhone(string customer_phone);
        Task<IResult<bool>> DeleteOrder(OrderRequestModel orderRequestModel);

    }
}
