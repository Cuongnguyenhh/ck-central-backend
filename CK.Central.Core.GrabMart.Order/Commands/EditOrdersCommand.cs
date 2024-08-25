using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class EditOrdersCommand : IRequest<EditOrderResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public EditOrdersCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class EditOrdersCommandHandler : IRequestHandler<EditOrdersCommand, EditOrderResponseDto>
    {
        private readonly IOrderActivityRepository _repository;
        public EditOrdersCommandHandler(IOrderActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EditOrderResponseDto> Handle(EditOrdersCommand request, CancellationToken cancellationToken)
        {

            return new EditOrderResponseDto();
        }
    }
}
