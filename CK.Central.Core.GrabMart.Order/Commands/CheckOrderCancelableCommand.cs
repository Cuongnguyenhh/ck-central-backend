using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class CheckOrderCancelableCommand : IRequest<CheckOrderCancelableResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CheckOrderCancelableCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CheckOrderCancelableCommandHandler : IRequestHandler<CheckOrderCancelableCommand, CheckOrderCancelableResponseDto>
    {
        private readonly IOrderCancelableRepository _repository;
        public CheckOrderCancelableCommandHandler(IOrderCancelableRepository repository)
        {
            _repository = repository;
        }

        public async Task<CheckOrderCancelableResponseDto> Handle(CheckOrderCancelableCommand request, CancellationToken cancellationToken)
        {

            return new CheckOrderCancelableResponseDto();
        }
    }
}
