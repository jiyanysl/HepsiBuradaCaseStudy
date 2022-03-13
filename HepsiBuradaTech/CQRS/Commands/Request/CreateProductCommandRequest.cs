using HepsiBuradaTech.CQRS.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
