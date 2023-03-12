using AutoMapper;
using SatelliteOrchestrator.API.Entities;
using SatelliteOrchestrator.API;
using SatelliteOrchestrator.API.Repositories;
using Eventbus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SatelliteOrchestrator.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SatelliteOrchestratorController : ControllerBase
    {
        private readonly ISatelliteOrchestratorRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public SatelliteOrchestratorController(ISatelliteOrchestratorRepository repository, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        [HttpGet("{userName}", Name = "GetSatelliteOrchestrator")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetSatelliteOrchestrator(string userName)
        {
            var SatelliteOrchestrator = await _repository.GetSatelliteOrchestrator(userName);
            return Ok(SatelliteOrchestrator ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateSatelliteOrchestrator([FromBody] ShoppingCart SatelliteOrchestrator)
        {
            // TODO : Communicate with SatelliteOrchestratorController.Grpc
            // and Calculate latest prices of product into shopping cart.
            foreach (var item in SatelliteOrchestrator.Items)
            {
        
            
            }
            return Ok(await _repository.UpdateSatelliteOrchestrator(SatelliteOrchestrator));
        }

        [HttpDelete("{userName}", Name = "DeleteSatelliteOrchestrator")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSatelliteOrchestrator(string userName)
        {
            await _repository.DeleteSatelliteOrchestrator(userName);
            return Ok();    
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] SatelliteOrchestratorCheckout SatelliteOrchestratorCheckout)
        {
            // get existing SatelliteOrchestrator with total price
            // create SatelliteOrchestratorcheckoutevent -- set totalprice on SatelliteOrchestratorcheckout eventMessage
            // send checkout event to rabbitmq
            // remove the SatelliteOrchestrator

            // get existing SatelliteOrchestrator with total price
            var SatelliteOrchestrator = await _repository.GetSatelliteOrchestrator(SatelliteOrchestratorCheckout.UserName);
            if (SatelliteOrchestrator == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<SatelliteOrchestratorCheckoutEvent>(SatelliteOrchestratorCheckout);
            eventMessage.TotalPrice = SatelliteOrchestrator.TotalPrice;
            await _publishEndpoint.Publish<SatelliteOrchestratorCheckoutEvent>(eventMessage);

            // remove the SatelliteOrchestrator
            await _repository.DeleteSatelliteOrchestrator(SatelliteOrchestrator.UserName);

            return Accepted();
        }
    }
}
