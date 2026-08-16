using CqrsAndMediatRInAspNetCore.DataStore;
using CqrsAndMediatRInAspNetCore.Queries;
using MediatR;

namespace CqrsAndMediatRInAspNetCore.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
	{
		private readonly FakeDataStore _fakeDataStore;

		public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

		public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
			CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
	}
}
