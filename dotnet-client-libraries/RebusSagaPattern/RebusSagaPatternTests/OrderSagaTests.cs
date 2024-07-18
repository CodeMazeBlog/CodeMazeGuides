using NSubstitute;
using Rebus.TestHelpers;
using Rebus.TestHelpers.Events;
using RebusSagaPattern.Models;
using RebusSagaPattern.Repositories;
using RebusSagaPattern.Sagas.Handlers;
using RebusSagaPattern.Sagas.Messages;
using RebusSagaPattern.Sagas.SagaData;

namespace RebusSagaPatternTests;

public class OrderSagaTests
{
    private IOrderRepository _repositoryMock;
    private readonly Guid _orderId = Guid.Parse("60517f32-50af-4a87-a91a-3132ae30f2ac");

    [SetUp]
    public void Setup()
    {
        var order = new Order
        {
            OrderId = _orderId,
            Status = OrderStatus.Placed
        };

        _repositoryMock = Substitute.For<IOrderRepository>();
        _repositoryMock.GetOrderById(_orderId).Returns(order);
    }
    
    [Test]
    public void WhenPlaceOrderCommandIsReceived_ThenSagaDataIsInitialized()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));

        fixture.Deliver(new PlaceOrderCommand
        {
            OrderId = _orderId
        });
        
        var data = fixture.Data
            .OfType<OrderSagaData>()
            .FirstOrDefault();

        Assert.That(data, Is.Not.Null);
        Assert.That(data.OrderId, Is.EqualTo(_orderId));
    }

    [Test]
    public void WhenProcessPaymentCommandIsReceived_ThenShipOrderCommandIsSend()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));
        fixture.Add(new OrderSagaData
        {
            OrderId = _orderId
        });

        fixture.Deliver(new ProcessPaymentCommand
        {
            OrderId = _orderId
        });

        var command = busMock.Events
            .OfType<MessageSent<ShipOrderCommand>>()
            .Single()
            .CommandMessage;

        Assert.That(command, Is.Not.Null);
        Assert.That(command.OrderId, Is.EqualTo(_orderId));
    }
    
    [Test]
    public void WhenShipOrderCommandIsReceived_ThenOrderShippedEventIsSend()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));
        fixture.Add(new OrderSagaData
        {
            OrderId = _orderId
        });

        fixture.Deliver(new ShipOrderCommand
        {
            OrderId = _orderId
        });

        var command = busMock.Events
            .OfType<MessageSent<OrderShippedEvent>>()
            .Single()
            .CommandMessage;

        Assert.That(command, Is.Not.Null);
        Assert.That(command.OrderId, Is.EqualTo(_orderId));
    }
    
    [Test]
    public void WhenProcessPaymentMessageIsReceived_ThenSagaDataIsUpdated()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));
        fixture.Add(new OrderSagaData
        {
            OrderId = _orderId
        });

        fixture.Deliver(new ProcessPaymentCommand
        {
            OrderId = _orderId
        });
        
        var data = fixture.Data
            .OfType<OrderSagaData>()
            .FirstOrDefault();

        Assert.That(data, Is.Not.Null);
        Assert.That(data.IsPaymentProcessed, Is.True);
    }
    
    [Test]
    public void WhenShipOrderCommandIsReceived_ThenSagaDataIsUpdated()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));
        fixture.Add(new OrderSagaData
        {
            OrderId = _orderId
        });

        fixture.Deliver(new ShipOrderCommand
        {
            OrderId = _orderId
        });
        
        var data = fixture.Data
            .OfType<OrderSagaData>()
            .FirstOrDefault();

        Assert.That(data, Is.Not.Null);
        Assert.That(data.IsOrderShipped, Is.True);
    }

    [Test]
    public void WhenSagaIsMarkedAsCompleted_ThenSagaDataIsDisposed()
    {
        using var busMock = new FakeBus();
        using var fixture = SagaFixture.For(() => new OrderSaga(busMock, _repositoryMock));
        fixture.Add(new OrderSagaData
        {
            OrderId = _orderId
        });

        fixture.Deliver(new OrderShippedEvent
        {
            OrderId = _orderId
        });
        
        var data = fixture.Data
            .OfType<OrderSagaData>()
            .FirstOrDefault();

        Assert.That(data, Is.Null);
    }
}