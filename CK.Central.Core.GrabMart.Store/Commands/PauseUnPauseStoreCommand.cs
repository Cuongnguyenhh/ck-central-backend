using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Store.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Store.Commands
{
    public class PauseUnPauseStoreCommand : IRequest<TemporarilyPauseStoreResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public PauseUnPauseStoreCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class PauseUnPauseStoreCommandHandler : IRequestHandler<PauseUnPauseStoreCommand, TemporarilyPauseStoreResponseDto>
    {
        private readonly IStorePauseRepository _repository;
        public PauseUnPauseStoreCommandHandler(IStorePauseRepository repository)
        {
            _repository = repository;
        }

        public async Task<TemporarilyPauseStoreResponseDto> Handle(PauseUnPauseStoreCommand request, CancellationToken cancellationToken)
        {

            return new TemporarilyPauseStoreResponseDto();
        }
    }
}
