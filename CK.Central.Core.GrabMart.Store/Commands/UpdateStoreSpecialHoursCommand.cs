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
    public class UpdateStoreSpecialHoursCommand : IRequest<UpdateSpecialHoursResponseDto>
    {
        public Guid MenuId { get; set; }
        public string? MerchantID { get; set; }
        public string? PartnerMerchantID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateStoreSpecialHoursCommand()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }

    public class UpdateStoreSpecialHoursCommandHandler : IRequestHandler<UpdateStoreSpecialHoursCommand, UpdateSpecialHoursResponseDto>
    {
        private readonly IStorePauseRepository _repository;
        public UpdateStoreSpecialHoursCommandHandler(IStorePauseRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateSpecialHoursResponseDto> Handle(UpdateStoreSpecialHoursCommand request, CancellationToken cancellationToken)
        {

            return new UpdateSpecialHoursResponseDto();
        }
    }
}
