using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Menu.Commands
{
    public class UpdateMenuRecordCommand : IRequest<UpdateMenuRecordResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateMenuRecordCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateMenuRecordCommandHandler : IRequestHandler<UpdateMenuRecordCommand, UpdateMenuRecordResponseDto>
    {
        private readonly IMenuRecordRepository _repository;
        public UpdateMenuRecordCommandHandler(IMenuRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateMenuRecordResponseDto> Handle(UpdateMenuRecordCommand request, CancellationToken cancellationToken)
        {

            return new UpdateMenuRecordResponseDto();
        }
    }
}
