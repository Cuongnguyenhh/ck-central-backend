using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Store.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Store.Commands
{
    public class CheckHoursStoreCommand : IRequest<GetStoreHoursResponseDto>
    {
        public Guid StoreId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CheckHoursStoreCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CheckHoursStoreCommandHandler : IRequestHandler<CheckHoursStoreCommand, GetStoreHoursResponseDto>
    {
        private readonly IStoreHoursRepository _repository;
        public CheckHoursStoreCommandHandler(IStoreHoursRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetStoreHoursResponseDto> Handle(CheckHoursStoreCommand request, CancellationToken cancellationToken)
        {

            return new GetStoreHoursResponseDto();
        }
    }
}
