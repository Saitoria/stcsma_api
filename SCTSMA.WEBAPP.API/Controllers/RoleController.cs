using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Role;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS;
using System.Net;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Role Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository) 
        { 
            _roleRepository = roleRepository;
        }
        /// <summary>
        /// API endpoint for displaying all roles.
        /// </summary>
        /// <returns>The response with list of all roles.</returns>
        /// <response code="200">Successfully retrieved roles.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllRoles")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<RoleResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _roleRepository.GetAllRoles();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
