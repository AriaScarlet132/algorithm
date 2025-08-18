
using Microsoft.AspNetCore.Mvc;

namespace Rcbi.WebApi
{
    public class StatusController : ApiControllerBase
    {
        [Route("/status")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetStatus()
        {
            return "OK";
        }
    }
}
