using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class UpdateOrderReadyTimeCommand : IRequest<UpdateNewReadyTimeResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateOrderReadyTimeCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateOrderReadyTimeCommandHandler : IRequestHandler<UpdateOrderReadyTimeCommand, UpdateNewReadyTimeResponseDto>
    {
        private readonly IOrderActivityRepository _repository;
        public UpdateOrderReadyTimeCommandHandler(IOrderActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateNewReadyTimeResponseDto> Handle(UpdateOrderReadyTimeCommand request, CancellationToken cancellationToken)
        {

            return new UpdateNewReadyTimeResponseDto();
        }
    }
}
