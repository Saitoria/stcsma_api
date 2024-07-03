using SCTSMA.DOMAIN.Models.Dispute;
using SCTSMA.DOMAIN.Models.Payment;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IDisputeRepository
    {
        Task<IResult<List<DisputeResponseModel>>> GetAllDisputes();
        Task<IResult<DisputeResponseModel>> GetDisputeById(int dispute_id);
        Task<IResult<List<DisputeResponseModel>>> GetDisputesBySellerPhone(string seller_phone);
        Task<IResult<List<DisputeResponseModel>>> GetDisputesByCustomerPhone(string customer_phone);
        Task<IResult<bool>> CreateDispute(DisputeRequestModel disputeRequestModel);
        Task<IResult<bool>> UpdateDispute(DisputeRequestModel disputeRequestModel);
        Task<IResult<bool>> DeleteDispute(int dispute_id);
    }
}
