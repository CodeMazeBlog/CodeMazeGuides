var services = new ServiceCollection();

services.AddDependencies();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetService<IAnimalService>()!
   .PrintName("Cat");