using AutoMapper;
using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Commands.Response;
using HepsiBuradaTech.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Products>(request);
            await _context.Products.InsertOneAsync(product, cancellationToken: cancellationToken);

            return new CreateProductCommandResponse
            {
                Id = product.Id
            };
        }
    }
}
