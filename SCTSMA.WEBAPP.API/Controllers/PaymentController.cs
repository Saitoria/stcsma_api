using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Payment;
using SCTSMA.UTILS;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Payment Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        /// <summary>
        /// Constructor for PaymentController.
        /// </summary>
        /// <param name="paymentRepository">The payment repository instance.</param>
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        /// <summary>
        /// API endpoint for retrieving all payments.
        /// </summary>
        /// <returns>The response with list of all payments.</returns>
        /// <response code="200">Successfully retrieved payments.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllPayments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<PaymentResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPayments()
        {
            var response = await _paymentRepository.GetAllPayments();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving payments by customer phone number.
        /// </summary>
        /// <param name="customerPhone">The customer's phone number.</param>
        /// <returns>The response with the list of payments for the given customer phone number.</returns>
        /// <response code="200">Successfully retrieved payments.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetPaymentByCustomer/{customerPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<PaymentResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPaymentByCustomer(string customerPhone)
        {
            var response = await _paymentRepository.GetPaymentByCustomer(customerPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving payments by payment provider phone number.
        /// </summary>
        /// <param name="paymentProviderPhone">The payment provider's phone number.</param>
        /// <returns>The response with the list of payments for the given payment provider phone number.</returns>
        /// <response code="200">Successfully retrieved payments.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetPaymentByProvider/{paymentProviderPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<PaymentResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPaymentByProvider(string paymentProviderPhone)
        {
            var response = await _paymentRepository.GetPaymentByProvider(paymentProviderPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving payments by seller phone number.
        /// </summary>
        /// <param name="sellerPhone">The seller's phone number.</param>
        /// <returns>The response with the list of payments for the given seller phone number.</returns>
        /// <response code="200">Successfully retrieved payments.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetPaymentBySeller/{sellerPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<PaymentResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPaymentBySeller(string sellerPhone)
        {
            var response = await _paymentRepository.GetPaymentBySeller(sellerPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for creating a new payment.
        /// </summary>
        /// <param name="paymentRequestModel">The payment details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Payment created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("CreatePayment")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestModel paymentRequestModel)
        {
            var response = await _paymentRepository.CreatePayment(paymentRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for updating an existing payment.
        /// </summary>
        /// <param name="paymentRequestModel">The updated payment details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Payment updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdatePayment")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentRequestModel paymentRequestModel)
        {
            var response = await _paymentRepository.UpdatePayment(paymentRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
