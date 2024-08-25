using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class ListOrdersCommand : IRequest<ListOrdersResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public ListOrdersCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class ListOrdersCommandHandler : IRequestHandler<ListOrdersCommand, ListOrdersResponseDto>
    {
        private readonly IOrderListRepository _repository;
        public ListOrdersCommandHandler(IOrderListRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListOrdersResponseDto> Handle(ListOrdersCommand request, CancellationToken cancellationToken)
        {

            return new ListOrdersResponseDto();
        }
    }
}
