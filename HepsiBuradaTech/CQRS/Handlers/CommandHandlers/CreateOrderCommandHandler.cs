using AutoMapper;
using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Commands.Response;
using HepsiBuradaTech.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Orders>(request);
            await _context.Orders.InsertOneAsync(order, cancellationToken: cancellationToken);

            return new CreateOrderCommandResponse
            {
                Id = order.Id
            };
        }
    }
}
