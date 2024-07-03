using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS;
using System.Net;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for User Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    //[EnableCors("AllowAnyOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// API endpoint for displaying all users.
        /// </summary>
        /// <returns>The response with list of all users.</returns>
        /// <response code="200">Successfully retrieved users.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllUsers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<UserModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userRepository.GetUsers();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for displaying users by their role.
        /// </summary>
        /// <returns>The response will list users by their role_id.</returns>
        /// <response code="200">Successfully retrieved users.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetUsersByRoleId/{role_id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<UserModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsersByRoleId(int role_id)
        {
            var response = await _userRepository.GetUsersByRole(role_id);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for adding a new user.
        /// </summary>
        /// <param name="UserModel">The user model.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">User added successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddUser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddUser([FromBody] UserModel UserModel)
        {
            var response = await _userRepository.CreateUser(UserModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }


        /// <summary>
        /// API endpoint for user login.
        /// </summary>
        /// <param name="userLoginRqModel">The user login request model.</param>
        /// <returns>The response with the user details and role name.</returns>
        /// <response code="200">User logged in successfully.</response>
        /// <response code="400">Invalid phone number or password.</response>
        [HttpPost("LoginUser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<UserLoginResModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRqModel userLoginRqModel)
        {
            var response = await _userRepository.LoginUser(userLoginRqModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for signing up a new user.
        /// </summary>
        /// <param name="userAuthModel">The user authentication model.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">User signed up successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("SignupUser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignupUser([FromBody] UserAuthModel userAuthModel)
        {
            var response = await _userRepository.SignupUser(userAuthModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for signing up a new business owner.
        /// </summary>
        /// <param name="businessOwnerAuthModel">The business owner authentication model.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">Business owner signed up successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("SignupBusinessOwner")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignupBusinessOwner([FromBody] BusinessOwnerAuthModel businessOwnerAuthModel)
        {
            var response = await _userRepository.SignupBusinessOwner(businessOwnerAuthModel);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// API endpoint for deleting a user by phone number.
        /// </summary>
        /// <param name="phone_number">The phone number of the user to delete.</param>
        /// <returns>The response with a success status.</returns>
        /// <response code="200">User deleted successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteUser/{phone_number}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUser(string phone_number)
        {
            var response = await _userRepository.DeleteUser(phone_number);
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
