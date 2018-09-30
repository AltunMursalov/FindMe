using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using FindMeServer.NotificationConfig;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FindMeServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LostsController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IDataService dataService;

        public LostsController(IDataService dataService, IAuthenticationService authenticationService)
        {
            this.dataService = dataService;
            this.authenticationService = authenticationService;
        }

        [HttpGet("/api/[controller]/getlosts")]
        public async Task<ActionResult> GetLosts()
        {
            var losts = await this.dataService.GetLosts();
            if (Enumerable.Count(losts) > 0)
                return Json(losts);
            else if (losts is null)
                return StatusCode((int)HttpStatusCode.InternalServerError);
            else
                return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPut("/api/[controller]/editlost")]
        public async Task<ActionResult> EditLost([FromBody]Lost lost)
        {
            var result = await this.dataService.EditLost(lost);
            if (result == true)
                return StatusCode((int)HttpStatusCode.OK);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("/api/[controller]/getlostsbyinstitution/{id}")]
        public async Task<ActionResult> GetLostsByInstitution(int id)
        {
            var result = await this.dataService.GetLostsByInstitution(id);
            if (result != null)
                return Json(result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("/api/[controller]/deletelost/{id}")]
        public async Task<ActionResult> DeleteLost(int id)
        {
            var result = await this.dataService.DeleteLost(id);
            if (result == true)
                return StatusCode((int)HttpStatusCode.OK);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("/api/[controller]/newlost")]
        public async Task<JsonResult> CreateLost([FromBody]Lost lost)
        {
            return Json(await this.dataService.RegisterLost(lost));
        }
    }
}