using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.POS.GrabMart.Stock.Commands
{
    public class CheckStockCommand : IRequest<CheckStockResponseDto>
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }

        public CheckStockCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CheckStockCommandHandler : IRequestHandler<CheckStockCommand, CheckStockResponseDto>
    {
        private readonly IStockItemRepository _repository;
        public CheckStockCommandHandler(IStockItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<CheckStockResponseDto> Handle(CheckStockCommand request, CancellationToken cancellationToken)
        {

            return new CheckStockResponseDto();
        }
    }
}
