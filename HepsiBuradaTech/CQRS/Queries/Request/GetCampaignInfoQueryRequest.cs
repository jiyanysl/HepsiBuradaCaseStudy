using HepsiBuradaTech.CQRS.Queries.Response;
using MediatR;

namespace HepsiBuradaTech.CQRS.Queries.Request
{
    public class GetCampaignInfoQueryRequest : IRequest<GetCampaignInfoQueryResponse>
    {
        public string Name { get; set; }
    }
}
