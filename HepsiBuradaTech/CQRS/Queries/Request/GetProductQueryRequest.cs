using HepsiBuradaTech.CQRS.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Queries.Request
{
    public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
    {
        public string ProductCode { get; set; }
    }
}
