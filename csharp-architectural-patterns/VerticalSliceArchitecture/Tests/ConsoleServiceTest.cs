namespace Tests
{
    public class ConsoleServiceTest
    {
        private DataContext _context;

        [Fact]
        public async Task WhenGetAllConsoles_ThenConsolesAreReturnedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("consoleDB1")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            await _context.SaveChangesAsync();

            //When
            var consoles = await new ConsoleService(_context).GetAllConsolesAsync();

            //Then
            Assert.NotNull(consoles);

            Assert.True(consoles.Any());
        }

        [Fact]
        public async Task WhenGetConsoleById_ThenSpecificConsoleIsReturned()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("consoleDB2")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            await _context.SaveChangesAsync();

            //When
            var console = await new ConsoleService(_context).GetConsoleByIdAsync(1);

            await _context.SaveChangesAsync();

            //Then
            Assert.NotNull(console);

            Assert.True(console.Id == 1);
        }
    }
}