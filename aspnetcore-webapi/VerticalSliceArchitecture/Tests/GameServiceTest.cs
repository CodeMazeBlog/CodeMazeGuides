namespace Tests
{
    public class GameServiceTest
    {
        private DataContext _context;

        [Fact]
        public async Task WhenGameIsAdded_GameCreatedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("gameDB1")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            //When
            new GameService(_context).AddGameToConsole(1, new Game { Id = 10, Name = "Fighting Simulator", Publisher = "Best Fights Corp" });

            await _context.SaveChangesAsync();

            //Then
            Assert.True(await _context.Games.FirstOrDefaultAsync() != null);
        }

        [Fact]
        public async Task WhenGetAllGames_ThenGamesAreReturnedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("gameDB2")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            new GameService(_context).AddGameToConsole(1, new Game { Id = 10, Name = "Fighting Simulator", Publisher = "Best Fights Corp" });

            await _context.SaveChangesAsync();

            //When
            var games = await new GameService(_context).GetAllGamesAsync(1);

            //Then
            Assert.NotNull(games);

            Assert.True(games.Any());
        }

        [Fact]
        public async Task WhenGetGameByID_ThenSpecifiedGameIsReturnedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("gameDB3")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            new GameService(_context).AddGameToConsole(1, new Game { Id = 12, Name = "Running Simulator", Publisher = "Best Runs Corp" });

            await _context.SaveChangesAsync();

            //When
            var game = await new GameService(_context).GetGameAsync(1, 12);

            //Then
            Assert.NotNull(game);

            Assert.True(game.Id == 12);
        }

        [Fact]
        public async Task WhenDeletingAGame_ThenSpecifiedGameIsDeletedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("gameDB4")
                .Options;

            _context = new DataContext(options);

            _context.Consoles.Add(new GameConsole
            {
                Id = 1,
                Name = "Xbox Series X",
                Manufacturer = "Microsoft"
            });

            var newGame = new Game { Id = 13, Name = "Game Dev Simulator", Publisher = "Worst Games Corp" };

            new GameService(_context).AddGameToConsole(1, newGame);

            await _context.SaveChangesAsync();

            //When
            new GameService(_context).DeleteGame(newGame);

            await _context.SaveChangesAsync();

            //Then

            var deletedGame = await _context.Games.FirstOrDefaultAsync(x => x.Id == 13);

            Assert.Null(deletedGame);
        }
    }
}
