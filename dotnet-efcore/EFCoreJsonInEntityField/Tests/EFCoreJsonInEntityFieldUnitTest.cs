using EFCoreJsonInEntityField.Models;
using EFCoreJsonInEntityField;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class EFCoreJsonInEntityFieldUnitTest
    {
        [Fact]
        public async void GivenOrder_WhenAdded_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            // Act
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                // Assert
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                Assert.NotNull(savedOrder);
                Assert.Equal(order.Id, savedOrder.Id);
                Assert.Equal(order.ShippingInfo, savedOrder.ShippingInfo);
            }
        }

        [Fact]
        public async void GivenOrder_WhenNewShipmentAdded_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Act
                savedOrder.ShippingInfo.Shipments.Add(
                    new Shipment() 
                    { Carrier = "Ever Logistics",
                        ShipDate = DateTime.Now,
                        TrackingNumber = "A/98402" 
                    });
                context.SaveChanges();
                var updatedOrder = await context.Orders
                   .SingleOrDefaultAsync(o => o.Id == order.Id);
                
                // Assert
                Assert.Equal(2,updatedOrder.ShippingInfo.Shipments.Count);
                Assert.Equal(updatedOrder.Id, savedOrder.Id);
            }
        }

        [Fact]
        public async void GivenOrder_WhenNewDeliveryAdded_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Act
                savedOrder.ShippingInfo.Deliveries.Add(
                    new Delivery()
                    {
                        DeliveryDate =DateTime.Now,
                        ReceiverName = "Mark Twain",
                        Signature = "Mark Twain..."
                    });
                context.SaveChanges();
                var updatedOrder = await context.Orders
                   .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Assert
                Assert.Equal(2, updatedOrder.ShippingInfo.Deliveries.Count);
                Assert.Equal(updatedOrder.Id, savedOrder.Id);
            }
        }

        [Fact]
        public async void GivenOrder_WhenNewShipmentAndDeliveryAdded_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Act
                savedOrder.ShippingInfo.Shipments.Add(
                   new Shipment()
                   {
                       Carrier = "Ever Logistics",
                       ShipDate = DateTime.Now,
                       TrackingNumber = "A/98402"
                   });
                savedOrder.ShippingInfo.Deliveries.Add(
                    new Delivery()
                    {
                        DeliveryDate = DateTime.Now,
                        ReceiverName = "Mark Twain",
                        Signature = "Mark Twain..."
                    });
                context.SaveChanges();
                var updatedOrder = await context.Orders
                   .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Assert
                Assert.Equal(2, updatedOrder.ShippingInfo.Shipments.Count);
                Assert.Equal(2, updatedOrder.ShippingInfo.Deliveries.Count);
                Assert.Equal(updatedOrder.Id, savedOrder.Id);
            }
        }

        [Fact]
        public async void GivenOrder_WhenAddressUpdated_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Act
                savedOrder.ShippingInfo.Address = "Wall Street";
                context.SaveChanges();
                var updatedOrder = await context.Orders
                   .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Assert
                Assert.NotNull(updatedOrder);
                Assert.Equal(updatedOrder.Id, savedOrder.Id);                
                Assert.Equal(updatedOrder.ShippingInfo.Address, savedOrder.ShippingInfo.Address);
            }
        }

        [Fact]
        public async void GivenOrder_WhenShipmentCarrierUpdated_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "40192345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/360548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();
                var savedOrder = await context.Orders
                    .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Act
                var firstShipment = savedOrder.ShippingInfo.Shipments.FirstOrDefault();
                firstShipment.Carrier = "Chrisdan LLC";
                context.SaveChanges();
                var updatedOrder = await context.Orders
                   .SingleOrDefaultAsync(o => o.Id == order.Id);

                // Assert
                Assert.NotNull(updatedOrder);
                Assert.Equal(updatedOrder.Id, savedOrder.Id);
                Assert.Equal(updatedOrder.ShippingInfo.Shipments.FirstOrDefault().Carrier, firstShipment.Carrier);
            }
        }

        [Fact]
        public async void GivenOrder_WhenQueriedByCity_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address= "South Park St",
                City = "New York",
                State = "New York",               
                PostalCode = "210492345"               
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/100548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName="John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {                
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName="John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                // Act
                var queryOrders = await context.Orders
                   .Where(o => o.ShippingInfo.City == shippingInfo.City).ToListAsync();
                
                // Assert
                Assert.Single(queryOrders);
                Assert.Equal(queryOrders.FirstOrDefault().ShippingInfo.City, shippingInfo.City);
            }
        }

        [Fact]
        public async void GivenOrder_WhenQueriedByShipmentDate_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "210492345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/100548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                // Act
                var queryOrders = await context.Orders
                   .Select(o => new { order =o, shipments = o.ShippingInfo.Shipments }).Where(o => o.shipments.Any(sh=> sh.ShipDate.Date== shipment.ShipDate.Date)).Select(o=> o.order).ToListAsync();

                // Assert
                Assert.Single(queryOrders);                
            }
        }
        
        [Fact]
        public async void GivenOrder_WhenOrderDeleted_ThenShouldSucceed()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "210492345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/100548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                // Act
                var findOrder = await context.Orders
                   .Where(o => o.Id == order.Id).FirstOrDefaultAsync();
                context.Orders.Remove(findOrder);
                context.SaveChanges();
                var afterDeleteFindOrder = await context.Orders
                   .Where(o => o.Id == order.Id).FirstOrDefaultAsync();
                
                // Assert
                Assert.Null(afterDeleteFindOrder);
                Assert.Equal(EntityState.Detached,context.Entry(findOrder).State);
                Assert.Equal(findOrder.ShippingInfo.City, shippingInfo.City);
            }
        }

        [Fact]
        public async void GivenOrder_WhenDeliveryIsDeleted_ThenShouldSucced()
        {
            //Arrange
            var shippingInfo = new ShippingInfo
            {
                Address = "South Park St",
                City = "New York",
                State = "New York",
                PostalCode = "210492345"
            };
            var shipment = new Shipment()
            {
                Carrier = "Ever Logistics",
                ShipDate = DateTime.Now,
                TrackingNumber = "A/100548"
            };
            shippingInfo.Shipments.Add(shipment);
            var delivery = new Delivery()
            {
                DeliveryDate = DateTime.Now,
                ReceiverName = "John Due",
                Signature = "John Due..."
            };
            shippingInfo.Deliveries.Add(delivery);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                ShippingInfo = shippingInfo,
                CustomerName = "John Due",
                OrderDate = DateTime.Now,
            };
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                // Act
                var findOrder = await context.Orders
                   .Where(o => o.Id == order.Id).FirstOrDefaultAsync();
                var findDelivery = findOrder.ShippingInfo.Deliveries
                    .Where(d => d.ReceiverName == delivery.ReceiverName 
                    && d.DeliveryDate == delivery.DeliveryDate
                    && d.Signature == delivery.Signature).FirstOrDefault();
                findOrder.ShippingInfo.Deliveries.Remove(findDelivery);
                await context.SaveChangesAsync();
                var afterDeleteFindOrder = await context.Orders
                   .Where(o => o.Id == order.Id).FirstOrDefaultAsync();

                // Assert
                Assert.NotNull(afterDeleteFindOrder);
                Assert.Empty(findOrder.ShippingInfo.Deliveries);
            }
        }
    }
}
