using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Dispute;
using SCTSMA.UTILS;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Dispute Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DisputeController : ControllerBase
    {
        private readonly IDisputeRepository _disputeRepository;

        /// <summary>
        /// Constructor for DisputeController.
        /// </summary>
        /// <param name="disputeRepository">The dispute repository instance.</param>
        public DisputeController(IDisputeRepository disputeRepository)
        {
            _disputeRepository = disputeRepository;
        }

        /// <summary>
        /// API endpoint for retrieving all disputes.
        /// </summary>
        /// <returns>The response with the list of all disputes.</returns>
        /// <response code="200">Successfully retrieved disputes.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllDisputes")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<DisputeResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllDisputes()
        {
            var response = await _disputeRepository.GetAllDisputes();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving a dispute by its ID.
        /// </summary>
        /// <param name="dispute_id">The ID of the dispute.</param>
        /// <returns>The response with the dispute details.</returns>
        /// <response code="200">Successfully retrieved the dispute.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetDisputeById/{dispute_id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<DisputeResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDisputeById(int dispute_id)
        {
            var response = await _disputeRepository.GetDisputeById(dispute_id);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving disputes by customer phone number.
        /// </summary>
        /// <param name="customer_phone">The customer's phone number.</param>
        /// <returns>The response with the list of disputes for the given customer phone number.</returns>
        /// <response code="200">Successfully retrieved disputes.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetDisputesByCustomerPhone/{customer_phone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<DisputeResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDisputesByCustomerPhone(string customer_phone)
        {
            var response = await _disputeRepository.GetDisputesByCustomerPhone(customer_phone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving disputes by seller phone number.
        /// </summary>
        /// <param name="seller_phone">The seller's phone number.</param>
        /// <returns>The response with the list of disputes for the given seller phone number.</returns>
        /// <response code="200">Successfully retrieved disputes.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetDisputesBySellerPhone/{seller_phone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<DisputeResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDisputesBySellerPhone(string seller_phone)
        {
            var response = await _disputeRepository.GetDisputesBySellerPhone(seller_phone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for creating a new dispute.
        /// </summary>
        /// <param name="disputeRequestModel">The dispute details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Dispute created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("CreateDispute")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateDispute([FromBody] DisputeRequestModel disputeRequestModel)
        {
            var response = await _disputeRepository.CreateDispute(disputeRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for updating an existing dispute.
        /// </summary>
        /// <param name="disputeRequestModel">The updated dispute details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Dispute updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateDispute")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDispute([FromBody] DisputeRequestModel disputeRequestModel)
        {
            var response = await _disputeRepository.UpdateDispute(disputeRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for deleting a dispute.
        /// </summary>
        /// <param name="dispute_id">The ID of the dispute to delete.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Dispute deleted successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteDispute/{dispute_id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteDispute(int dispute_id)
        {
            var response = await _disputeRepository.DeleteDispute(dispute_id);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
