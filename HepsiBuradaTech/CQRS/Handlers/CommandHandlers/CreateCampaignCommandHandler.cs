using AutoMapper;
using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Commands.Response;
using HepsiBuradaTech.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.CommandHandlers
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommandRequest, CreateCampaignCommandResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

       
        public CreateCampaignCommandHandler()
        {
        }

        public CreateCampaignCommandHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            var campaign = _mapper.Map<Campaigns>(request);

            await _context.Campaigns.InsertOneAsync(campaign, cancellationToken: cancellationToken);
            return new CreateCampaignCommandResponse
            {
                Id = campaign.Id
            };
        }
    }
}
