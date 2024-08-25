using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Store.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Store.Commands
{
    public class CheckStatusStoreCommand : IRequest<GetStoreStatusResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CheckStatusStoreCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CheckStatusStoreCommandHandler : IRequestHandler<CheckStatusStoreCommand, GetStoreStatusResponseDto>
    {
        private readonly IStoreStatusRepository _repository;
        public CheckStatusStoreCommandHandler(IStoreStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetStoreStatusResponseDto> Handle(CheckStatusStoreCommand request, CancellationToken cancellationToken)
        {

            return new GetStoreStatusResponseDto();
        }
    }
}
