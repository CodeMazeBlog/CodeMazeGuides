var services = new ServiceCollection();

var configuration = new ConfigurationBuilder().Build();

services.AddDependencies();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetService<IAnimalService>()!
   .PrintName("Cat");