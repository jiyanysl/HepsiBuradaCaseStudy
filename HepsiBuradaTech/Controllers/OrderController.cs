using HepsiBuradaTech.CQRS.Commands.Request;
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
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommandRequest requestModel)
        {
            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return StatusCode(201, result);
        }
    }
}
