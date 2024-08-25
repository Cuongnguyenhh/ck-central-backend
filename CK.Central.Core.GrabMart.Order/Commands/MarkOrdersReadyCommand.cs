using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class MarkOrdersReadyCommand : IRequest<MarkOrderAsReadyResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public MarkOrdersReadyCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class MarkOrdersReadyCommandHandler : IRequestHandler<MarkOrdersReadyCommand, MarkOrderAsReadyResponseDto>
    {
        private readonly IOrderReadyRepository _repository;
        public MarkOrdersReadyCommandHandler(IOrderReadyRepository repository)
        {
            _repository = repository;
        }

        public async Task<MarkOrderAsReadyResponseDto> Handle(MarkOrdersReadyCommand request, CancellationToken cancellationToken)
        {

            return new MarkOrderAsReadyResponseDto();
        }
    }
}
