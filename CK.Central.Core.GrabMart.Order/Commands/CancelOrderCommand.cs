using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class CancelOrderCommand : IRequest<CancelOrderResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CancelOrderCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponseDto>
    {
        private readonly IOrderCancelableRepository _repository;
        public CancelOrderCommandHandler(IOrderCancelableRepository repository)
        {
            _repository = repository;
        }

        public async Task<CancelOrderResponseDto> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {

            return new CancelOrderResponseDto();
        }
    }
}
