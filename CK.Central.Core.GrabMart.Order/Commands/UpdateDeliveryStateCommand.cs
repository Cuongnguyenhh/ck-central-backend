using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class UpdateDeliveryStateCommand : IRequest<UpdateDeliveryStateResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateDeliveryStateCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateDeliveryStateCommandHandler : IRequestHandler<UpdateDeliveryStateCommand, UpdateDeliveryStateResponseDto>
    {
        private readonly IOrderActivityRepository _repository;
        public UpdateDeliveryStateCommandHandler(IOrderActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateDeliveryStateResponseDto> Handle(UpdateDeliveryStateCommand request, CancellationToken cancellationToken)
        {

            return new UpdateDeliveryStateResponseDto();
        }
    }
}
