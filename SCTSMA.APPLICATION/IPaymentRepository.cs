using SCTSMA.DOMAIN.Models.Payment;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IPaymentRepository
    {
        Task<IResult<List<PaymentResponseModel>>> GetAllPayments();
        Task<IResult<List<PaymentResponseModel>>> GetPaymentByProvider(string payment_provider_phone);
        Task<IResult<List<PaymentResponseModel>>> GetPaymentByCustomer(string customer_phone);
        Task<IResult<List<PaymentResponseModel>>> GetPaymentBySeller(string seller_phone);
        Task<IResult<bool>> CreatePayment(PaymentRequestModel paymentRequestModel);
        Task<IResult<bool>> UpdatePayment(PaymentRequestModel paymentRequestModel);
    }
}
