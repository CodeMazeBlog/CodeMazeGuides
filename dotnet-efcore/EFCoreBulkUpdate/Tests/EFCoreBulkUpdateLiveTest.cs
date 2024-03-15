using EFCoreBulkUpdate.Creator;
using EFCoreBulkUpdate.Model;
using EFCoreBulkUpdate.Services;
using FluentAssertions;

namespace Tests
{
    public class EFCoreBulkUpdateLiveTest : TestDatabaseFixture
    {
        private const int TeamCount = 3;
        private const int PlayerCountPerTeam = 2;
        private const int GameCount = 2;
        private const int RefereeCount = 2;

        [Fact]
        public async Task WhenExecuteUpdateTeamsYearAndDescriptionV2_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            TeamService teamService = new TeamService(context);
            var teams = TeamCreator.CreateTeamsWithPlayers(TeamCount, PlayerCountPerTeam);
            await teamService.AddTeams(teams);

            // Act
            int numberOfUpdatedRows = await teamService.UpdateAllTeamsYearAndDescription_V2("Newly Added");

            //Assert
            numberOfUpdatedRows.Should().Be(TeamCount);
        }

        [Fact]
        public async Task WhenExecuteUpdateTeamsYearAndDescriptionV1_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            TeamService teamService = new TeamService(context);
            var teams = TeamCreator.CreateTeamsWithPlayers(TeamCount, PlayerCountPerTeam);
            await teamService.AddTeams(teams);

            //Act
            int numberOfUpdatedRows = await teamService.UpdateAllTeamsYearAndDescription_V1("Newly Added");

            //Assert
            numberOfUpdatedRows.Should().Be(TeamCount);
        }

        [Fact]
        public async Task WhenExecuteDeleteAllTeamsV1_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            TeamService teamService = new TeamService(context);
            var teams = TeamCreator.CreateTeamsWithPlayers(TeamCount, PlayerCountPerTeam);
            await teamService.AddTeams(teams);

            //Act
            var numberOfDeletedRows = await teamService.DeleteAllTeams_V1();

            //Assert
            numberOfDeletedRows.Should().Be(TeamCount+TeamCount*PlayerCountPerTeam);
        }

        [Fact]
        public async Task WhenExecuteDeleteAllTeamsV2_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            TeamService teamService = new TeamService(context);
            var teams = TeamCreator.CreateTeamsWithPlayers(TeamCount, PlayerCountPerTeam);
            await teamService.AddTeams(teams);

            //Act
            var numberOfDeletedRows = await teamService.DeleteAllTeams_V2();

            //Assert
            numberOfDeletedRows.Should().Be(TeamCount);
        }

        [Fact]
        public async Task WhenDeleteAllRefereesWithTPC_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            EmployeeService employeeService = new EmployeeService(context);
            var referees = EmployeeCreator.CreateReferees(RefereeCount);
            await employeeService.AddReferees(referees.ToList());

            // Act
            var numberOfDeletedRows = await employeeService.DeleteAllReferees();

            //Assert
            numberOfDeletedRows.Should().Be(RefereeCount);
        }

        [Fact]
        public async Task WhenUpdateAllRefereesWithTPC_ThenShouldSucceed()
        {
            //Arrange
            var context = CreateContext();
            EmployeeService employeeService = new EmployeeService(context);
            var referees = EmployeeCreator.CreateReferees(RefereeCount);
            await employeeService.AddReferees(referees.ToList());

            // Act
            var numberOfUpdatedRows = await employeeService.UpdateAllRefereesYearsExperience();

            //Assert
            numberOfUpdatedRows.Should().Be(RefereeCount);
        }
        
        [Fact]
        public async Task WhenDeleteGamesWithTPT_ThenShouldReturnError()
        {
            //Arrange
            var context = CreateContext();
            EmployeeService employeeService = new EmployeeService(context);
            var footballGames = GameCreator.CreateFootballGames(GameCount);
            GameService gameService = new GameService(context);
            TeamService teamService = new TeamService(context);
            var teams = new List<Team>() { footballGames.FirstOrDefault().Team };
            await teamService.AddTeams(teams);
            await gameService.AddGames(footballGames);

            //Act and Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => gameService.DeleteAllFootballGames());
        }

        [Fact]
        public async Task WhenUpdateGamesWithTPT_ThenShouldReturnError()
        {
            //Arrange
            var context = CreateContext();
            EmployeeService employeeService = new EmployeeService(context);
            var footballGames = GameCreator.CreateFootballGames(GameCount);
            var teams = new List<Team>() { footballGames.FirstOrDefault().Team };
            GameService gameService = new GameService(context);
            TeamService teamService = new TeamService(context);
            await teamService.AddTeams(teams);
            await gameService.AddGames(footballGames);

            //Act and Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => gameService.UpdateAllGames("new opponent"));
        }
    }
}