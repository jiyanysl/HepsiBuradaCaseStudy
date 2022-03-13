using AutoMapper;
using HepsiBuradaTech.CQRS.Queries.Request;
using HepsiBuradaTech.CQRS.Queries.Response;
using HepsiBuradaTech.Enum;
using HepsiBuradaTech.Models;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.QueryHandlers
{
    public class GetCampaignInfoQueryHandler : IRequestHandler<GetCampaignInfoQueryRequest, GetCampaignInfoQueryResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

        public GetCampaignInfoQueryHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCampaignInfoQueryResponse> Handle(GetCampaignInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var campaign = await _context
                           .Campaigns
                           .Find(x => x.Name == request.Name)
                           .FirstOrDefaultAsync(cancellationToken);

            // Verilen case çalışmasında net bir şekilde belirtilmediğinden, 
            // kampanyanın oluşturulma saatini başlangıç saati olarak tasarladım.
            // Hepsinin Date olarak tanımlanması daha sağlıklı bir sonuç çıkarırdı.

            int endDate = Convert.ToInt32(campaign.StartDate.Hour) - (campaign.Duration);

            if (endDate > Convert.ToInt32(campaign.StartDate.Hour))
            {
                campaign.CampaignStatus = "Active";
            }
            else
            {
                campaign.CampaignStatus = "Ended";
            }
            var result = _mapper.Map<GetCampaignInfoQueryResponse>(campaign);
            return result;
        }
    }
}
