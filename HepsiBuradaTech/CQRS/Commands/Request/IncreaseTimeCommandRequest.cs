using HepsiBuradaTech.CQRS.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBuradaTech.CQRS.Commands.Request
{
    public class IncreaseTimeCommandRequest : IRequest<IncreaseTimeCommandResponse>
    {
        public int IncTime { get; set; }
        public string CampaignName { get; set; }
    }
}
