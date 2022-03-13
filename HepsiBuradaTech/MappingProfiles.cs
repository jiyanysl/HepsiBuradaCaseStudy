using AutoMapper;
using HepsiBuradaTech.CQRS.Commands.Request;
using HepsiBuradaTech.CQRS.Queries.Response;
using HepsiBuradaTech.Models;

namespace HepsiBuradaTech
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Product
            CreateMap<CreateProductCommandRequest, Products>();
            CreateMap<Products, GetProductQueryResponse>();

            #endregion

            #region Order
            CreateMap<CreateOrderCommandRequest, Orders>();
            #endregion

            #region Campaign
            CreateMap<CreateCampaignCommandRequest, Campaigns>();
            CreateMap<Campaigns, GetCampaignInfoQueryResponse>();
            #endregion


        }

    }
}
