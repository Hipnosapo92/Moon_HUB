using Microsoft.AspNetCore.Mvc;
using MoonHotels_HUB_DTO;
using MoonHotels_HUB_Service;

namespace MoonHotels_HUB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoonHotelsHUBController : ControllerBase
    {
        private readonly ILogger<MoonHotelsHUBController> _logger;

        public MoonHotelsHUBController(ILogger<MoonHotelsHUBController> logger)
        {
            _logger = logger;
        }

        [HttpPost("search")]
        public IList<MoonHotels_Communication_Response> Search([FromBody] MoonHotels_Communication_Request request)
        {
            List<MoonHotels_Communication_Response> response = new List<MoonHotels_Communication_Response>();
            MoonHotels_HUB_SRV service = MoonHotels_HUB_SRV.GetService();

            service.Search(request, response);

            return response;
        }

    }
}