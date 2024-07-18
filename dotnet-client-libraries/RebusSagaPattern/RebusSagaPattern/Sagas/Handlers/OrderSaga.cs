using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using RebusSagaPattern.Models;
using RebusSagaPattern.Repositories;
using RebusSagaPattern.Sagas.Messages;
using RebusSagaPattern.Sagas.SagaData;

namespace RebusSagaPattern.Sagas.Handlers;

public class OrderSaga : Saga<OrderSagaData>, 
    IAmInitiatedBy<PlaceOrderCommand>,
    IHandleMessages<ProcessPaymentCommand>, 
    IHandleMessages<ShipOrderCommand>,
    IHandleMessages<OrderShippedEvent>
{
    private readonly IBus _bus;
    private readonly IOrderRepository _orderRepository;

    public OrderSaga(IBus bus, IOrderRepository orderRepository)
    {
        _bus = bus;
        _orderRepository = orderRepository;
    }
        
    protected override void CorrelateMessages(ICorrelationConfig<OrderSagaData> config)
    {
        config.Correlate<PlaceOrderCommand>(m => m.OrderId, d => d.OrderId);
        config.Correlate<ProcessPaymentCommand>(m => m.OrderId, d => d.OrderId);
        config.Correlate<ShipOrderCommand>(m => m.OrderId, d => d.OrderId);
        config.Correlate<OrderShippedEvent>(m => m.OrderId, d => d.OrderId);
    }

    public Task Handle(PlaceOrderCommand message)
    {
        Data.OrderId = message.OrderId;
        Data.IsOrderPlaced = true;

        _orderRepository.AddOrder(new()
        {
            OrderId = message.OrderId,
            Status = OrderStatus.Placed
        });
        
        return Task.CompletedTask;
    }

    public async Task Handle(ProcessPaymentCommand message)
    {
        Data.IsPaymentProcessed = true;

        var order = _orderRepository.GetOrderById(message.OrderId);
        order.Status = OrderStatus.Processing;
            
        await _bus.Send(new ShipOrderCommand { OrderId = Data.OrderId });
    }
        
    public async Task Handle(ShipOrderCommand message)
    {
        Data.IsOrderShipped = true;
            
        await _bus.Send(new OrderShippedEvent { OrderId = Data.OrderId });
    }

    public Task Handle(OrderShippedEvent message)
    {
        var order = _orderRepository.GetOrderById(message.OrderId);
        order.Status = OrderStatus.Completed;
            
        MarkAsComplete();
        
        return Task.CompletedTask;
    }
}