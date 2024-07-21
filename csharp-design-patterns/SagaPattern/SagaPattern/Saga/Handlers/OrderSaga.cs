using SagaPattern.Repositories;
using SagaPattern.Saga.Messages;
using SagaPattern.Saga.SagaData;

namespace SagaPattern.Saga.Handlers
{
    public class OrderSaga : Saga<OrderSagaData>, 
        IAmStartedByMessages<StartOrder>, 
        IHandleMessages<ProcessPayment>, 
        IHandleMessages<PrepareShipment>
    {
        private readonly IOrderRepository _repository;

        public OrderSaga(IOrderRepository repository)
        {
            _repository = repository;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper) 
        { 
            mapper.ConfigureMapping<StartOrder>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId); 
            mapper.ConfigureMapping<ProcessPayment>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId); 
            mapper.ConfigureMapping<PrepareShipment>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId); 
        } 
        
public async Task Handle(StartOrder message, IMessageHandlerContext context) 
{ 
    Data.OrderId = message.OrderId;

    var order = await _repository.GetOrderById(message.OrderId);
    order.Status = Models.OrderStatus.PaymentPending;

    await context.SendLocal(new ProcessPayment { OrderId = message.OrderId }); 
} 
        
public async Task Handle(ProcessPayment message, IMessageHandlerContext context) 
{ 
    Data.PaymentProcessed = true;

    var order = await _repository.GetOrderById(message.OrderId);
    order.Status = Models.OrderStatus.Processing;

    await context.SendLocal(new PrepareShipment { OrderId = message.OrderId }); 
} 
        
public async Task Handle(PrepareShipment message, IMessageHandlerContext context) 
{ 
    Data.ShipmentPrepared = true;

    var order = await _repository.GetOrderById(message.OrderId);
    order.Status = Models.OrderStatus.OrderCompleted;

    await context.Publish(new OrderCompleted { OrderId = message.OrderId }); 
    MarkAsComplete();
} 
    }
}
