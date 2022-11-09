using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PublisherController : ControllerBase
    {
        private const string ComponentName = "[PublisherControler]";
        private readonly IPublisherService _publisherService;
        private readonly ILogger _logger;

        public PublisherController(ILogger<PublisherController> logger,
                              IPublisherService publisherService)
        {
            _logger = logger;
            _publisherService = publisherService;
        }

        /// <summary>
        /// Returns a list of the publishers of the books from the Middle Earth
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((typeof(ICollection<Resources.DataTransferObjects.Response.Publisher>)), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPublishers()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publishers through GetPublishers");

            var publishers = await _publisherService.GetPublishers();

            _logger.LogInformation($"{ComponentName} - Retrieved {publishers.Count} books through GetPublishers");

            return Ok(publishers);
        }

        /// <summary>
        /// Returns information regarding a publisher by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType((typeof(Resources.DataTransferObjects.Response.Publisher)), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publisher through GetPublisherById with the following id: {id}");

            var publisher = await _publisherService.GetPublisherById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"{ComponentName} - Retrieved publisher with id {id} through GetPublisherById");

            return Ok(publisher);
        }
    }
}