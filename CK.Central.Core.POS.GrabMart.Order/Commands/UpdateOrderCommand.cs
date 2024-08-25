using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.POS.GrabMart.Order.Commands
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResponseDto>
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateOrderCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResponseDto>
    {
        private readonly IOrderUpdateRepository _repository;
        public UpdateOrderCommandHandler(IOrderUpdateRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderResponseDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            return new UpdateOrderResponseDto();
        }
    }
}
