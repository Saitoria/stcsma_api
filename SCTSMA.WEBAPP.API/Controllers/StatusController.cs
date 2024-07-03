using Microsoft.AspNetCore.Mvc;
using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Status;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS;
using System.Net;

namespace SCTSMA.WEBAPP.API.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Status Management.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository) 
        { 
            _statusRepository = statusRepository;
        }

        /// <summary>
        /// API endpoint for displaying all statuses.
        /// </summary>
        /// <returns>The response with list of all statuses.</returns>
        /// <response code="200">Successfully retrieved statuses.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAllstatuses")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<List<StatusResponseModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllstatuses()
        {
            var response = await _statusRepository.GetAllStatuses();
            if (response.succeeded)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
