using CqrsAndMediatRInAspNetCore.Commands;
using CqrsAndMediatRInAspNetCore.DataStore;
using MediatR;

namespace CqrsAndMediatRInAspNetCore.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product> 
    { 
        private readonly FakeDataStore _fakeDataStore; 
        
        public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore; 
        
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken) 
        {
            await _fakeDataStore.AddProduct(request.Product); 
            
            return request.Product; 
        } 
    }
}
