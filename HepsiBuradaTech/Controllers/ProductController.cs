using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HepsiBuradaTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return StatusCode(201, result);
        }


        [HttpGet("GetProductInfo")]
        public async Task<IActionResult> Get(string productCode)
        {
            var requestModel = new GetProductQueryRequest
            {
                ProductCode = productCode
            };

            var result = await _mediator.Send(requestModel);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
