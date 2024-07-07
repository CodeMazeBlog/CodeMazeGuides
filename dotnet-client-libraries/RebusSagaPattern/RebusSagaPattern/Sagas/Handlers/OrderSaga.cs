using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using RebusSagaPattern.Models;
using RebusSagaPattern.Repositories;
using RebusSagaPattern.Sagas.Messages;
using RebusSagaPattern.Sagas.SagaData;

namespace RebusSagaPattern.Sagas.Handlers
{
    public class OrderSaga : Saga<OrderSagaData>, 
        IAmInitiatedBy<OrderPlacedEvent>,
        IHandleMessages<PaymentProcessedEvent>, 
        IHandleMessages<ShipOrderCommand>,
        IHandleMessages<OrderShippedEvent>
    {
        private IBus _bus;
        private readonly IOrderRepository _orderRepository;

        public OrderSaga(IBus bus, IOrderRepository orderRepository)
        {
            _bus = bus;
            _orderRepository = orderRepository;
        }
        
        protected override void CorrelateMessages(ICorrelationConfig<OrderSagaData> config)
        {
            config.Correlate<OrderPlacedEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<PaymentProcessedEvent>(m => m.OrderId, d => d.OrderId);
            config.Correlate<ShipOrderCommand>(m => m.OrderId, d => d.OrderId);
            config.Correlate<OrderShippedEvent>(m => m.OrderId, d => d.OrderId);
        }

        public async Task Handle(OrderPlacedEvent message)
        {
            Data.OrderId = message.OrderId;
            Data.IsOrderPlaced = true;

            await _orderRepository.AddOrder(new()
            {
                OrderId = message.OrderId,
                Status = OrderStatus.Placed
            });
        }

        public async Task Handle(PaymentProcessedEvent message)
        {
            Data.IsPaymentProcessed = true;

            var order = await _orderRepository.GetOrderById(message.OrderId);
            order.Status = OrderStatus.Processing;
            
            await _bus.Send(new ShipOrderCommand { OrderId = Data.OrderId });
        }
        
        public async Task Handle(ShipOrderCommand message)
        {
            await _bus.Send(new OrderShippedEvent { OrderId = Data.OrderId });
        }

        public async Task Handle(OrderShippedEvent message)
        {
            Data.IsOrderShipped = true;
            
            var order = await _orderRepository.GetOrderById(message.OrderId);
            order.Status = OrderStatus.Completed;
            
            MarkAsComplete();
        }
    }
}