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
    public class UpdateCampaignCommand : IRequest<UpdateCampaignResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateCampaignCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, UpdateCampaignResponseDto>
    {
        private readonly ICampaignActivityRepository _repository;
        public UpdateCampaignCommandHandler(ICampaignActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCampaignResponseDto> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {

            return new UpdateCampaignResponseDto();
        }
    }
}
