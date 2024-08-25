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
    public class DeleteCampaignCommand : IRequest<DeleteCampaignResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public DeleteCampaignCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, DeleteCampaignResponseDto>
    {
        private readonly ICampaignActivityRepository _repository;
        public DeleteCampaignCommandHandler(ICampaignActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCampaignResponseDto> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {

            return new DeleteCampaignResponseDto();
        }
    }
}
