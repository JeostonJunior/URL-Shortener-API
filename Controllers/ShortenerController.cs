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
        public ActionResult<UrlModel> AssignLinkToShortPost([FromBody] string url)
        {

            if (string.IsNullOrEmpty(url))
            {
                return StatusCode(StatusCodes.Status400BadRequest, url);
            }

            var assignLink = _assignLinkService.AssignShortId(url);

            if (string.IsNullOrEmpty(assignLink))
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status201Created, assignLink);
        }


        //[Route("Me.Leva.La/{url}")]
        //[HttpGet]
        //public IActionResult LevaLaShortenUrl(string url)
        //{
        //    try
        //    {
        //        var redirectUrl = _assignLinkService.GetAssignLink(url);

        //        if (string.IsNullOrEmpty(redirectUrl))
        //        {
        //            return BadRequest();
        //        }

        //        return Redirect(redirectUrl);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
    }
}
