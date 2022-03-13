using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBuradaTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCampaign")]
        public async Task<IActionResult> Post([FromBody] CreateCampaignCommandRequest requestModel)
        {
            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return StatusCode(201, result);
        }

        [HttpGet("GetCampaignInfo")]
        public async Task<IActionResult> Get(string name)
        {
            var requestModel = new GetCampaignInfoQueryRequest
            {
                Name = name
            };

            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost("IncreaseTime")]
        public async Task<IActionResult> Post([FromBody] IncreaseTimeCommandRequest requestModel)
        {
            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return StatusCode(201, result);
        }
    }
}
