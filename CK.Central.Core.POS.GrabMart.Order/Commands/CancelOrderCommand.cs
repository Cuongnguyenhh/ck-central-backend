using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.GrabMart.Order.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Order.Mapping;
using MediatR;

namespace CK.Central.Core.POS.GrabMart.Order.Commands
{
    public class CancelOrderCommand : IRequest<CancelOrderResponseDto>
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }

        public CancelOrderCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponseDto>
    {
        private readonly IOrderCancelRepository _repository;
        public CancelOrderCommandHandler(IOrderCancelRepository repository)
        {
            _repository = repository;
        }

        public async Task<CancelOrderResponseDto> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {

            return new CancelOrderResponseDto();
        }
    }
}
