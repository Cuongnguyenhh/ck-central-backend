using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.GrabMart.Order.Abstract.Repositories;
using MediatR;

namespace CK.Central.Core.POS.GrabMart.Order.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResponseDto>
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateOrderCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponseDto>
    {
        private readonly IOrderSubmitRepository _repository;
        public CreateOrderCommandHandler(IOrderSubmitRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            return new CreateOrderResponseDto();
        }
    }
}
