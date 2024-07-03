using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Order;
using SCTSMA.UTILS;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Order Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Constructor for OrderController.
        /// </summary>
        /// <param name="orderRepository">The order repository instance.</param>
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// API endpoint for retrieving all orders.
        /// </summary>
        /// <returns>The response with list of all orders.</returns>
        /// <response code="200">Successfully retrieved orders.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllOrders")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<OrderResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderRepository.GetAllOrders();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving orders by customer phone number.
        /// </summary>
        /// <param name="customerPhone">The customer's phone number.</param>
        /// <returns>The response with the list of orders for the given customer phone number.</returns>
        /// <response code="200">Successfully retrieved orders.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetOrdersByCustomerPhone/{customerPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<OrderResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrdersByCustomerPhone(string customerPhone)
        {
            var response = await _orderRepository.GetOrdersByCustomerPhone(customerPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving orders by seller phone number.
        /// </summary>
        /// <param name="sellerPhone">The seller's phone number.</param>
        /// <returns>The response with the list of orders for the given seller phone number.</returns>
        /// <response code="200">Successfully retrieved orders.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetOrdersBySellerPhone/{sellerPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<OrderResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrdersBySellerPhone(string sellerPhone)
        {
            var response = await _orderRepository.GetOrdersBySellerPhone(sellerPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }


        /// <summary>
        /// API endpoint for creating a new order.
        /// </summary>
        /// <param name="orderRequestModel">The order details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Order created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("CreateOrder")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            var response = await _orderRepository.CreateOrder(orderRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for deleting an order.
        /// </summary>
        /// <param name="orderRequestModel">The order details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Order deleted successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteOrder")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            var response = await _orderRepository.DeleteOrder(orderRequestModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
