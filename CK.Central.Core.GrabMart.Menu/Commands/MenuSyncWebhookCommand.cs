using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Menu.Commands
{
    public class MenuSyncWebhookCommand : IRequest<PartnerMenuSyncWebhookResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public MenuSyncWebhookCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class MenuSyncWebhookCommandHandler : IRequestHandler<MenuSyncWebhookCommand, PartnerMenuSyncWebhookResponseDto>
    {
        private readonly IMenuSyncWebhookRepository _repository;
        public MenuSyncWebhookCommandHandler(IMenuSyncWebhookRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartnerMenuSyncWebhookResponseDto> Handle(MenuSyncWebhookCommand request, CancellationToken cancellationToken)
        {

            return new PartnerMenuSyncWebhookResponseDto();
        }
    }
}
