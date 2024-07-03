using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Product;
using SCTSMA.UTILS;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Product Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Constructor for ProductController.
        /// </summary>
        /// <param name="productRepository">The product repository instance.</param>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        /// <summary>
        /// API endpoint for retrieving all products.
        /// </summary>
        /// <returns>The response with list of all products.</returns>
        /// <response code="200">Successfully retrieved products.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllProducts")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<ProductModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productRepository.GetAllProducts();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>The response with the product details.</returns>
        /// <response code="200">Successfully retrieved the product.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetProductById/{productId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<ProductModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var response = await _productRepository.GetProductById(productId);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for retrieving products by seller phone number.
        /// </summary>
        /// <param name="sellerPhone">The seller's phone number.</param>
        /// <returns>The response with the list of products for the given seller phone number.</returns>
        /// <response code="200">Successfully retrieved products.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetProductsBySellerPhone/{sellerPhone}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<ProductModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductsBySellerPhone(string sellerPhone)
        {
            // Encode the seller phone number before sending it to the repository
            //string encodedSellerPhone = HttpUtility.UrlEncode(sellerPhone);

            var response = await _productRepository.GetProductsBySellerPhone(sellerPhone);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for creating a new product.
        /// </summary>
        /// <param name="productModel">The product details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Product created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("CreateProduct")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productModel)
        {
            var response = await _productRepository.CreateProduct(productModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }


        /// <summary>
        /// API endpoint for updating an existing product.
        /// </summary>
        /// <param name="productModel">The updated product details.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Product updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateProduct")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel)
        {
            var response = await _productRepository.UpdateProduct(productModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
