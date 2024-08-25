using AutoMapper;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Domain.DataObjects.POS.Request;
using CK.Central.Core.Domain.DataObjects.POS.Response;

namespace CK.Central.Core.POS.GrabMart.Stock.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StockActivityEntity, StockActivityRequestDto>().ReverseMap();
            CreateMap<StockActivityEntity, StockActivityResponseDto>().ReverseMap();
            CreateMap<StockActivityRequestDto, StockActivityEntity>().ReverseMap();
            CreateMap<StockActivityResponseDto, StockActivityEntity>().ReverseMap();

            CreateMap<StockHistoricalEntity, StockHistoricalRequestDto>().ReverseMap();
            CreateMap<StockHistoricalEntity, StockHistoricalResponseDto>().ReverseMap();
            CreateMap<StockHistoricalRequestDto, StockHistoricalEntity>().ReverseMap();
            CreateMap<StockHistoricalResponseDto, StockHistoricalEntity>().ReverseMap();

            CreateMap<StockItemEntity, StockItemRequestDto>().ReverseMap();
            CreateMap<StockItemEntity, StockItemResponseDto>().ReverseMap();
            CreateMap<StockItemRequestDto, StockItemEntity>().ReverseMap();
            CreateMap<StockItemResponseDto, StockItemEntity>().ReverseMap();

            CreateMap<StockServiceEntity, StockServiceRequestDto>().ReverseMap();
            CreateMap<StockServiceEntity, StockServiceResponseDto>().ReverseMap();
            CreateMap<StockServiceRequestDto, StockServiceEntity>().ReverseMap();
            CreateMap<StockServiceResponseDto, StockServiceEntity>().ReverseMap();
        }
    }
}
