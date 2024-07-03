using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Payment;
using SCTSMA.UTILS;
using SCTSMA.UTILS.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCTSMA.INFRASTRUCTURE
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbService _dbService;
        public PaymentRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResult<bool>> CreatePayment(PaymentRequestModel paymentRequestModel)
        {
            if (paymentRequestModel.payment_id != null || paymentRequestModel.order_id == 0)
            {
                return Result<bool>.Failure("Invalid payment or order ID.");
            }

            var result = await _dbService.EditData(
                @"INSERT INTO payments (order_id, payment_provider_phone, amount, transaction_cost, status_id, authorized_at, held_until, completed_at)
                  VALUES (@OrderId, @PaymentProviderPhone, @Amount, @TransactionCost, @StatusId, @AuthorizedAt, @HeldUntil, @CompletedAt)",
                new
                {
                    OrderId = paymentRequestModel.order_id,
                    PaymentProviderPhone = paymentRequestModel.payment_provider_phone,
                    Amount = paymentRequestModel.amount,
                    TransactionCost = paymentRequestModel.transaction_cost,
                    StatusId = paymentRequestModel.status_id,
                    AuthorizedAt = paymentRequestModel.authorized_at,
                    HeldUntil = paymentRequestModel.held_until,
                    CompletedAt = paymentRequestModel.completed_at
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to create payment.");
        }

        public async Task<IResult<List<PaymentResponseModel>>> GetAllPayments()
        {
            var result = await _dbService.GetAll<PaymentResponseModel>(
                @"SELECT p.payment_id, p.order_id, p.payment_provider_phone, u.first_name AS payment_first_name, u.last_name AS payment_last_name,
                         p.amount, p.transaction_cost, p.status_id, p.authorized_at, p.held_until, p.completed_at,
                         cu.phone_number AS customer_phone, cu.first_name AS customer_first_name, cu.last_name AS customer_last_name,
                         su.phone_number AS seller_phone, su.first_name AS seller_first_name, su.last_name AS seller_last_name
                  FROM payments p
                  JOIN users u ON p.payment_provider_phone = u.phone_number
                  JOIN orders o ON p.order_id = o.order_id
                  JOIN users cu ON o.customer_phone = cu.phone_number
                  JOIN users su ON o.seller_phone = su.phone_number",
                new { }
            );

            return result;
        }

        public async Task<IResult<List<PaymentResponseModel>>> GetPaymentByCustomer(string customer_phone)
        {
            var result = await _dbService.GetAll<PaymentResponseModel>(
                @"SELECT p.payment_id, p.order_id, p.payment_provider_phone, u.first_name AS payment_first_name, u.last_name AS payment_last_name,
                         p.amount, p.transaction_cost, p.status_id, p.authorized_at, p.held_until, p.completed_at,
                         cu.phone_number AS customer_phone, cu.first_name AS customer_first_name, cu.last_name AS customer_last_name,
                         su.phone_number AS seller_phone, su.first_name AS seller_first_name, su.last_name AS seller_last_name
                  FROM payments p
                  JOIN users u ON p.payment_provider_phone = u.phone_number
                  JOIN orders o ON p.order_id = o.order_id
                  JOIN users cu ON o.customer_phone = cu.phone_number
                  JOIN users su ON o.seller_phone = su.phone_number
                  WHERE cu.phone_number = @CustomerPhone",
                new { CustomerPhone = customer_phone }
            );

            return result;
        }

        public async Task<IResult<List<PaymentResponseModel>>> GetPaymentByProvider(string payment_provider_phone)
        {
            var result = await _dbService.GetAll<PaymentResponseModel>(
                @"SELECT p.payment_id, p.order_id, p.payment_provider_phone, u.first_name AS payment_first_name, u.last_name AS payment_last_name,
                         p.amount, p.transaction_cost, p.status_id, p.authorized_at, p.held_until, p.completed_at,
                         cu.phone_number AS customer_phone, cu.first_name AS customer_first_name, cu.last_name AS customer_last_name,
                         su.phone_number AS seller_phone, su.first_name AS seller_first_name, su.last_name AS seller_last_name
                  FROM payments p
                  JOIN users u ON p.payment_provider_phone = u.phone_number
                  JOIN orders o ON p.order_id = o.order_id
                  JOIN users cu ON o.customer_phone = cu.phone_number
                  JOIN users su ON o.seller_phone = su.phone_number
                  WHERE p.payment_provider_phone = @PaymentProviderPhone",
                new { PaymentProviderPhone = payment_provider_phone }
            );

            return result;
        }

        public async Task<IResult<List<PaymentResponseModel>>> GetPaymentBySeller(string seller_phone)
        {
            var result = await _dbService.GetAll<PaymentResponseModel>(
                @"SELECT p.payment_id, p.order_id, p.payment_provider_phone, u.first_name AS payment_first_name, u.last_name AS payment_last_name,
                         p.amount, p.transaction_cost, p.status_id, p.authorized_at, p.held_until, p.completed_at,
                         cu.phone_number AS customer_phone, cu.first_name AS customer_first_name, cu.last_name AS customer_last_name,
                         su.phone_number AS seller_phone, su.first_name AS seller_first_name, su.last_name AS seller_last_name
                  FROM payments p
                  JOIN users u ON p.payment_provider_phone = u.phone_number
                  JOIN orders o ON p.order_id = o.order_id
                  JOIN users cu ON o.customer_phone = cu.phone_number
                  JOIN users su ON o.seller_phone = su.phone_number
                  WHERE su.phone_number = @SellerPhone",
                new { SellerPhone = seller_phone }
            );

            return result;
        }

        public async Task<IResult<bool>> UpdatePayment(PaymentRequestModel paymentRequestModel)
        {
            var result = await _dbService.EditData(
                @"UPDATE payments
                  SET payment_provider_phone = @PaymentProviderPhone, amount = @Amount, transaction_cost = @TransactionCost,
                      status_id = @StatusId, authorized_at = @AuthorizedAt, held_until = @HeldUntil, completed_at = @CompletedAt
                  WHERE payment_id = @PaymentId AND order_id = @OrderId",
                new
                {
                    PaymentId = paymentRequestModel.payment_id,
                    OrderId = paymentRequestModel.order_id,
                    PaymentProviderPhone = paymentRequestModel.payment_provider_phone,
                    Amount = paymentRequestModel.amount,
                    TransactionCost = paymentRequestModel.transaction_cost,
                    StatusId = paymentRequestModel.status_id,
                    AuthorizedAt = paymentRequestModel.authorized_at,
                    HeldUntil = paymentRequestModel.held_until,
                    CompletedAt = paymentRequestModel.completed_at
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to update payment.");
        }
    }
}
