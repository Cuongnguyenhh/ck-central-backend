using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class PushOrderStateCommand : IRequest<PushOrderStateResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public PushOrderStateCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class PushOrderStateCommandHandler : IRequestHandler<PushOrderStateCommand, PushOrderStateResponseDto>
    {
        private readonly IOrderStateRepository _repository;
        public PushOrderStateCommandHandler(IOrderStateRepository repository)
        {
            _repository = repository;
        }

        public async Task<PushOrderStateResponseDto> Handle(PushOrderStateCommand request, CancellationToken cancellationToken)
        {

            return new PushOrderStateResponseDto();
        }
    }
}
