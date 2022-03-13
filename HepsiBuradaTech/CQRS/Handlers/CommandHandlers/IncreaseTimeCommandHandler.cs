using AutoMapper;
using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Commands.Response;
using HepsiBuradaTech.Models;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.CommandHandlers
{
    public class IncreaseTimeCommandHandler : IRequestHandler<IncreaseTimeCommandRequest, IncreaseTimeCommandResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;
        public IncreaseTimeCommandHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // İstenilen kampanyaların süresini istenilen süre kadar arttırır.
        public async Task<IncreaseTimeCommandResponse> Handle(IncreaseTimeCommandRequest request, CancellationToken cancellationToken)
        {
            var updateDefintion = Builders<Campaigns>.Update.Set(x => x.Duration, request.IncTime);


            var campaign = await _context
                         .Campaigns.UpdateManyAsync(c => c.Name == request.CampaignName, updateDefintion);

            return new IncreaseTimeCommandResponse
            {
                IncTime = request.IncTime
            };
        }
    }
}
