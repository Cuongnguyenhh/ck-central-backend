using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.GrabMart.Menu.Commands
{
    public class ListMartCategoriesCommand : IRequest<ListMartCategoriesResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public ListMartCategoriesCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class ListMartCategoriesCommandHandler : IRequestHandler<ListMartCategoriesCommand, ListMartCategoriesResponseDto>
    {
        private readonly IMenuCategoriesRepository _repository;
        public ListMartCategoriesCommandHandler(IMenuCategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListMartCategoriesResponseDto> Handle(ListMartCategoriesCommand request, CancellationToken cancellationToken)
        {

            return new ListMartCategoriesResponseDto();
        }
    }
}
