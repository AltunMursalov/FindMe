using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
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
        public JsonResult GetLosts()
        {
            return Json(this.dataService.GetLosts());
        }

        [HttpPost("/api/[controller]/newlost")]
        public async Task<JsonResult> CreateLost([FromBody]Lost lost)
        {
            if (lost != null)
            {

                return Json(await this.dataService.RegisterLost(lost));
            }
            else
            {
                return Json(null);
            }
        }
    }
}