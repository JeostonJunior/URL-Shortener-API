using LinkShortener.Models;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpGet, Route("TinyUrl/{url}")]
        public IActionResult RedirectToUrl(string url)
        {
            try
            {
                var redirectUrl = _assignLinkService.GetAssignLink(url);

                if (string.IsNullOrEmpty(redirectUrl))
                {
                    return BadRequest();
                }

                return Redirect(redirectUrl);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

    }
}
