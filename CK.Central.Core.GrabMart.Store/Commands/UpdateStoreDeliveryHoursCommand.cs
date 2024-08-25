using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Store.Abstract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Store.Commands
{
    public class UpdateStoreDeliveryHoursCommand : IRequest<UpdateDeliveryHoursResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateStoreDeliveryHoursCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateStoreDeliveryHoursCommandHandler : IRequestHandler<UpdateStoreDeliveryHoursCommand, UpdateDeliveryHoursResponseDto>
    {
        private readonly IStorePauseRepository _repository;
        public UpdateStoreDeliveryHoursCommandHandler(IStorePauseRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateDeliveryHoursResponseDto> Handle(UpdateStoreDeliveryHoursCommand request, CancellationToken cancellationToken)
        {

            return new UpdateDeliveryHoursResponseDto();
        }
    }
}
