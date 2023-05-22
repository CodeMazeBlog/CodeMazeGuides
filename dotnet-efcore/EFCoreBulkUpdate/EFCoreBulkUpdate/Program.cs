using EFCoreBulkUpdate;
using EFCoreBulkUpdate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var connectionString = configuration.GetConnectionString("teamConnection");

var optionsBuilder = new DbContextOptionsBuilder<TeamDBContext>();
optionsBuilder.UseSqlServer(connectionString);

using var dbcontext = new TeamDBContext(optionsBuilder.Options);
const int n = 4;
List<Team> teams = new List<Team>();
for (int i = 0; i < n; i++)
{
    teams.Add(new Team()
    {
        Id = Guid.NewGuid(),
        Description = string.Format("Description {0} for Code Maze", i.ToString()),
        Name = string.Format("Team {0}", i.ToString()),
        YearFounded = new Random().Next(1970, 2023),
    });
}
TeamService service = new TeamService(dbcontext);
await service.AddTeams(teams);
teams = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teams));

await service.UpdateAllTeamsYearAndDescription_V2("Newly Added");
var teamsAfterUpdate = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teamsAfterUpdate));

await service.DeleteAllTeams_V2();
var teamsAfterDelete = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teamsAfterDelete));

List<Player> players = new List<Player>();
for (int i = 0; i < n; i++)
{
    players.Add(new Player()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(20, 35),
        Name = string.Format("Name {0}", i.ToString()),
        TeamId = teams[i].Id
    });
}
await service.AddPlayersToTeams(players);
await service.DeleteAllTeams_V2();

//TPC
List<Referee> referees = new List<Referee>();
for (int i = 0; i < n; i++)
{
    referees.Add(new Referee()
    {
        Id = Guid.NewGuid(),
        FirstName = string.Format("First Name {0}", i.ToString()),
        LastName = string.Format("Last Name {0}", i.ToString()),
        LicenceNo = new Random().Next(60054, 70000).ToString(),
        Category = string.Format("Category {0}", i.ToString()),
        RefereeCode = new Random().Next(10000, 20000).ToString(),
        YearsExperience = new Random().Next(1,10),
    });
}
EmployeeService employeeService = new EmployeeService(dbcontext);
await employeeService.AddReferees(referees);
Console.WriteLine(employeeService.PrintReferees(referees));
await employeeService.DeleteEmployees(4);
referees = await employeeService.FindAllReferess();
Console.WriteLine(employeeService.PrintReferees(referees));

//TPT
List<Game> games = new List<Game>();
for (int i = 0; i < n; i++)
{
    games.Add(new FootballGame()
    {
        Id = Guid.NewGuid(),
        Date = DateTime.Now,
        FirstHalfTimeScore = i,
        SecondHalfTimeScore = i,
        Opponent = string.Format("Opponent {0}", i.ToString()),
        TeamId = teams[i].Id,
    });

    games.Add(new BasketballGame()
    {
        Id = Guid.NewGuid(),
        Date = DateTime.Now,
        Opponent = string.Format("Opponent {0}", i.ToString()),
        Quarter1Score = i,
        Quarter2Score = i,
        Quarter3Score = i,
        Quarter4Score = i,
        TeamId = teams[i].Id,
    });
}
GameService gameService = new GameService(dbcontext);
await gameService.AddGames(games);
Console.WriteLine(gameService.PrintGames(games));
await gameService.DeleteAllFootballs();