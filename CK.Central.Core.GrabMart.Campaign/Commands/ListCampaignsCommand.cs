using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Campaign.Abstract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Campaign.Commands
{
    public class ListCampaignsCommand : IRequest<ListCampaignsResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public ListCampaignsCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class ListCampaignsCommandHandler : IRequestHandler<ListCampaignsCommand, ListCampaignsResponseDto>
    {
        private readonly ICampaignListRepository _repository;
        public ListCampaignsCommandHandler(ICampaignListRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListCampaignsResponseDto> Handle(ListCampaignsCommand request, CancellationToken cancellationToken)
        {

            return new ListCampaignsResponseDto();
        }
    }
}
