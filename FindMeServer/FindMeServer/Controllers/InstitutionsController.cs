using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindMeServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InstitutionsController : Controller
    {
        private readonly IDataService dataService;
        private readonly IAuthenticationService authenticationService;

        public InstitutionsController(IDataService dataService, IAuthenticationService authenticationService)
        {
            this.dataService = dataService;
            this.authenticationService = authenticationService;
        }

        [HttpPost("/api/[controller]/registerinstitution")]
        public async Task<JsonResult> RegisterInstitution([FromBody]Institution institution)
        {
            if (institution != null)
            {
                return Json(await this.authenticationService.RegisterInstitution(institution));
            }
            else
            {
                return Json(null);
            }
        }

        public async Task<JsonResult> Login([FromBody]Institution institution)
        {
            return Json(await this.authenticationService.Login(institution));
        }

        [HttpGet("/api/[controller]/getinstitutions")]
        public JsonResult Get()
        {
            return Json(this.dataService.GetInstitutions());
        }
    }
}