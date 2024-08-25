using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Abstract.Services;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using CK.Central.Core.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Domain.GrabMart.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CK.Central.Core.GrabMart.Order.Commands
{
    public class SubmitOrdersCommand : GrabSubmitOrderRequestDto, IRequest<SubmitOrderResponseDto>
    {
        public SubmitOrdersCommand()
        { }
    }

    public class SubmitOrdersCommandHandler : IRequestHandler<SubmitOrdersCommand, SubmitOrderResponseDto>
    {
        private readonly IOrderSubmitRepository _repository;
        private readonly IRedisCacheGrabMartOrderService _redisCacheService;
        private readonly IKafkaProducerGrabMartService _kafkaProducerService;
        public SubmitOrdersCommandHandler(IOrderSubmitRepository repository,
            IRedisCacheGrabMartOrderService redisCacheService,
            IKafkaProducerGrabMartService kafkaProducerService)
        {
            _repository = repository;
            _redisCacheService = redisCacheService;
            _kafkaProducerService = kafkaProducerService;
        }

        public async Task<SubmitOrderResponseDto> Handle(SubmitOrdersCommand request, CancellationToken cancellationToken)
        {
            await _kafkaProducerService.ProduceEvent(KafkaTopicSend.pos_response_create_order_detail, JsonConvert.SerializeObject(request));

            return new SubmitOrderResponseDto { message = StatusCodes.Status204NoContent.ToString() };
        }
    }
}
