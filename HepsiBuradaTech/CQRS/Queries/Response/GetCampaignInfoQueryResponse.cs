using HepsiBuradaTech.Enum;
using System;

namespace HepsiBuradaTech.CQRS.Queries.Response
{
    public class GetCampaignInfoQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public string CampaignStatus { get; set; }

    }
}
