var services = new ServiceCollection();

services.AddDependencies();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetService<IPetService>()!
   .PrintName("Cat");

serviceProvider.GetService<IWildAnimalService>()!
   .PrintName("Tigers");

serviceProvider.GetService<IMarineAnimalsService>()!
   .PrintName("Dolphins");