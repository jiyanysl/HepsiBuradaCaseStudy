using HepsiBuradaTech.CQRS.Commands.Response;
using HepsiBuradaTech.Models;
using MediatR;

namespace HepsiBuradaTech.CQRS.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
