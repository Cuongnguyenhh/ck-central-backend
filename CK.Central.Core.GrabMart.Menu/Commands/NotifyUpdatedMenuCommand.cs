using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Menu.Commands
{
    public class NotifyUpdatedMenuCommand : IRequest<PartnerMenuNotificationResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public NotifyUpdatedMenuCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class NotifyUpdatedMenuCommandHandler : IRequestHandler<NotifyUpdatedMenuCommand, PartnerMenuNotificationResponseDto>
    {
        private readonly IMenuNotificationRepository _repository;
        public NotifyUpdatedMenuCommandHandler(IMenuNotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartnerMenuNotificationResponseDto> Handle(NotifyUpdatedMenuCommand request, CancellationToken cancellationToken)
        {

            return new PartnerMenuNotificationResponseDto();
        }
    }
}
