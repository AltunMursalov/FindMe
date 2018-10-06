using Microsoft.Azure.NotificationHubs.Messaging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

using System.Net;
using ApplicationCore.ServiceInterfaces;

namespace FindMeServer.Controllers
{
    [Produces("application/json")]
    [Route("api/register")]
    public class RegisterController : Controller
    {
        private readonly ISubscribeService subscribeService;

        public RegisterController(ISubscribeService subscribeService)
        {
            this.subscribeService = subscribeService;
        }

        // POST api/register
        // This creates a registration id
        [Route("{regId}")]
        public async Task<IActionResult> Post([FromBody]string[] tags, string regId)
        {
            var result = await this.subscribeService.Subsribe(tags, regId);
            if (result != null)
                return Ok();
            else
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
        }

        [HttpPost("api/[controller]/remove/{regId}")]
        public async Task<IActionResult> Delete([FromBody]string[] tags, string regId)
        {
            if (tags != null && regId != null)
            {
                var result = await this.subscribeService.Unsubscribe(tags, regId);
                if (result)
                    return StatusCode((int)HttpStatusCode.OK);
                else
                    return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}