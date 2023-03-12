using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System.Net;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IDataSatelliteService _DataSatelliteService;
        private readonly ISatelliteOrchestratorService _SatelliteOrchestratorService;
        private readonly ISatelliteOrchestratorControllerService _SatelliteOrchestratorControllerService;

        public ShoppingController(IDataSatelliteService DataSatelliteService, ISatelliteOrchestratorService SatelliteOrchestratorService, ISatelliteOrchestratorControllerService SatelliteOrchestratorControllerService)
        {
            _DataSatelliteService = DataSatelliteService;
            _SatelliteOrchestratorService = SatelliteOrchestratorService;
            _SatelliteOrchestratorControllerService = SatelliteOrchestratorControllerService;
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            var SatelliteOrchestrator = await _SatelliteOrchestratorService.GetSatelliteOrchestrator(userName);

            foreach (var item in SatelliteOrchestrator.Items)
            {
                var product = await _DataSatelliteService.GetDataSatellite(item.ProductId);

                // set additional product fields
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var SatelliteOrchestratorControllers = await _SatelliteOrchestratorControllerService.GetSatelliteOrchestratorControllersByUserName(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                SatelliteOrchestratorWithProducts = SatelliteOrchestrator,
                SatelliteOrchestratorControllers = SatelliteOrchestratorControllers
            };

            return Ok(shoppingModel);
        }

    }
}
