using LinkShortener.Model;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

        [Route("ShortUrl/{url}")]
        [HttpGet]       
        public ActionResult<LinkModel> AssignLinkToShortPost(string url)
        {
            try
            {
                var assignLink = _assignLinkService.AssignLink(url);

                if (string.IsNullOrEmpty(assignLink))
                {
                    return BadRequest();
                }

                return StatusCode(StatusCodes.Status201Created, assignLink);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [EnableCors("My Policy")]
        [Route("Me.Leva.La/{url}")]
        [HttpGet]
        public IActionResult LevaLaShortenUrl(string url)
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
