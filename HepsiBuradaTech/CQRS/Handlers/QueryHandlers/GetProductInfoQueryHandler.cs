using AutoMapper;
using HepsiBuradaTech.CQRS.Queries.Request;
using HepsiBuradaTech.CQRS.Queries.Response;
using HepsiBuradaTech.Models;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Handlers.QueryHandlers
{
    public class GetProductInfoQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

        public GetProductInfoQueryHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _context
                            .Products
                            .Find(x => x.ProductCode == request.ProductCode)
                            .FirstOrDefaultAsync(cancellationToken);

            // Verilen ProductCode field bilgisiyle eşleşen bir kampanya varsa ve 
            // kampanya hala devam ediyorsa Price bilgisini indirimli haliyle return eder.

            var campaignInfo = await _context
                          .Campaigns
                          .Find(x => x.ProductCode == product.ProductCode)
                          .FirstOrDefaultAsync(cancellationToken);

            if(campaignInfo != null && campaignInfo.CampaignStatus == "Active")
            {
                product.Price -= campaignInfo.PriceManipulationLimit;
            }

            var result = _mapper.Map<GetProductQueryResponse>(product);
            return result;
        }
    }
} 
