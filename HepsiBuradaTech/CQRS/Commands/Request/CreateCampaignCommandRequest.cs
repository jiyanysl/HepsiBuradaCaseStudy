using HepsiBuradaTech.CQRS.Commands.Response;
using MediatR;
using System;

namespace HepsiBuradaTech.CQRS.Commands.Request
{
    public class CreateCampaignCommandRequest : IRequest<CreateCampaignCommandResponse>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
