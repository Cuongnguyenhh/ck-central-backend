using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Campaign.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Campaign.Commands
{
    public class CreateCampaignCommand : IRequest<CreateCampaignsResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCampaignCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, CreateCampaignsResponseDto>
    {
        private readonly ICampaignActivityRepository _repository;
        public CreateCampaignCommandHandler(ICampaignActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCampaignsResponseDto> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {

            return new CreateCampaignsResponseDto();
        }
    }
}
