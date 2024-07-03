using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Dispute;
using SCTSMA.UTILS;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.INFRASTRUCTURE
{
    public class DisputeRepository : IDisputeRepository
    {
        private readonly IDbService _dbService;

        public DisputeRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResult<bool>> CreateDispute(DisputeRequestModel disputeRequestModel)
        {
            var result = await _dbService.EditData(
                @"INSERT INTO disputes (order_id, customer_phone, seller_phone, description, status_id, filed_at, resolved_at)
                  VALUES (@OrderId, @CustomerPhone, @SellerPhone, @Description, @StatusId, @FiledAt, @ResolvedAt)",
                new
                {
                    OrderId = disputeRequestModel.order_id,
                    CustomerPhone = disputeRequestModel.customer_phone,
                    SellerPhone = disputeRequestModel.seller_phone,
                    Description = disputeRequestModel.description,
                    StatusId = disputeRequestModel.status_id,
                    FiledAt = disputeRequestModel.filed_at,
                    ResolvedAt = disputeRequestModel.resolved_at
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to create dispute.");
        }

        public async Task<IResult<bool>> DeleteDispute(int dispute_id)
        {
            var result = await _dbService.EditData(
                "DELETE FROM disputes WHERE dispute_id = @DisputeId",
                new { DisputeId = dispute_id }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to delete dispute.");
        }

        public async Task<IResult<List<DisputeResponseModel>>> GetAllDisputes()
        {
            var result = await _dbService.GetAll<DisputeResponseModel>(
                @"SELECT d.dispute_id, d.order_id, d.customer_phone, c.first_name AS customer_first_name, c.last_name AS customer_last_name,
                         d.seller_phone, s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         d.description, d.status_id, d.filed_at, d.resolved_at
                  FROM disputes d
                  JOIN users c ON d.customer_phone = c.phone_number
                  JOIN users s ON d.seller_phone = s.phone_number",
                new { }
            );

            return result;
        }

        public async Task<IResult<DisputeResponseModel>> GetDisputeById(int dispute_id)
        {
            var result = await _dbService.GetAsync<DisputeResponseModel>(
                @"SELECT d.dispute_id, d.order_id, d.customer_phone, c.first_name AS customer_first_name, c.last_name AS customer_last_name,
                         d.seller_phone, s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         d.description, d.status_id, d.filed_at, d.resolved_at
                  FROM disputes d
                  JOIN users c ON d.customer_phone = c.phone_number
                  JOIN users s ON d.seller_phone = s.phone_number
                  WHERE d.dispute_id = @DisputeId",
                new { DisputeId = dispute_id }
            );

            return result;
        }

        public async Task<IResult<List<DisputeResponseModel>>> GetDisputesByCustomerPhone(string customer_phone)
        {
            var result = await _dbService.GetAll<DisputeResponseModel>(
                @"SELECT d.dispute_id, d.order_id, d.customer_phone, c.first_name AS customer_first_name, c.last_name AS customer_last_name,
                         d.seller_phone, s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         d.description, d.status_id, d.filed_at, d.resolved_at
                  FROM disputes d
                  JOIN users c ON d.customer_phone = c.phone_number
                  JOIN users s ON d.seller_phone = s.phone_number
                  WHERE d.customer_phone = @CustomerPhone",
                new { CustomerPhone = customer_phone }
            );

            return result;
        }

        public async Task<IResult<List<DisputeResponseModel>>> GetDisputesBySellerPhone(string seller_phone)
        {
            var result = await _dbService.GetAll<DisputeResponseModel>(
                @"SELECT d.dispute_id, d.order_id, d.customer_phone, c.first_name AS customer_first_name, c.last_name AS customer_last_name,
                         d.seller_phone, s.first_name AS seller_first_name, s.last_name AS seller_last_name, 
                         d.description, d.status_id, d.filed_at, d.resolved_at
                  FROM disputes d
                  JOIN users c ON d.customer_phone = c.phone_number
                  JOIN users s ON d.seller_phone = s.phone_number
                  WHERE d.seller_phone = @SellerPhone",
                new { SellerPhone = seller_phone }
            );

            return result;
        }

        public async Task<IResult<bool>> UpdateDispute(DisputeRequestModel disputeRequestModel)
        {
            var result = await _dbService.EditData(
                @"UPDATE disputes 
                  SET customer_phone = @CustomerPhone, seller_phone = @SellerPhone, description = @Description, 
                      status_id = @StatusId, resolved_at = @ResolvedAt
                  WHERE dispute_id = @DisputeId",
                new
                {
                    DisputeId = disputeRequestModel.dispute_id,
                    CustomerPhone = disputeRequestModel.customer_phone,
                    SellerPhone = disputeRequestModel.seller_phone,
                    Description = disputeRequestModel.description,
                    StatusId = disputeRequestModel.status_id,
                    ResolvedAt = disputeRequestModel.resolved_at
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to update dispute.");
        }
    }
}
