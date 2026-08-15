using CqrsAndMediatRInAspNetCore.DataStore;
using CqrsAndMediatRInAspNetCore.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsAndMediatRInAspNetCore.Handlers
{
	public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
	{
		private readonly FakeDataStore _fakeDataStore;

		public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
		{
			await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
			await Task.CompletedTask;
		}
	}
}
