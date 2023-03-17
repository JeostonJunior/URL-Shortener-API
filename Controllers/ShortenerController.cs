using LinkShortener.Models;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    [ApiController]
    public class ShortenerController : ControllerBase
    {

        private readonly ILogger<ShortenerController> _logger;
        private readonly IAssignLinkService _assignLinkService;

        public ShortenerController(ILogger<ShortenerController> logger, IAssignLinkService assignService)
        {
            _logger = logger;
            _assignLinkService = assignService;
        }

        [Route("ShortUrl")]
        [HttpPost]
        public ActionResult<TinyUrlRequest> AssignLinkToShortPost([FromBody] TinyUrlRequest url)
        {
            var assignLink = _assignLinkService.AssignShortId(url);

            if (string.IsNullOrEmpty(assignLink))
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status201Created, assignLink);
        }
    }
}
