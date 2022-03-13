using HepsiBuradaTech.Enum;
using System;

namespace HepsiBuradaTech.Models
{
    public class Campaigns : BaseEntity
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public DateTime StartDate
        {
            get
            {
                return DateTime.Now;
            }
        }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public string CampaignStatus{ get; set; }
    }
}
