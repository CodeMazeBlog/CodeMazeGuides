using EFCoreBulkUpdate;
using EFCoreBulkUpdate.Creator;
using EFCoreBulkUpdate.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var connectionString = configuration.GetConnectionString("teamConnection");

var optionsBuilder = new DbContextOptionsBuilder<TeamDBContext>();
optionsBuilder.UseSqlServer(connectionString);

const int TeamCount = 3;
const int PlayerCountPerTeam = 2;
const int GameCount = 2;
const int RefereeCount = 2;

var teams = TeamCreator.CreateTeamsWithPlayers(TeamCount, PlayerCountPerTeam);
using var dbcontext = new TeamDBContext(optionsBuilder.Options);
TeamService service = new TeamService(dbcontext);
await service.AddTeams(teams);
teams = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teams.ToList()));

await service.UpdateAllTeamsYearAndDescription_V2("Newly Added");
var teamsAfterUpdate = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teamsAfterUpdate));

await service.DeleteAllTeams_V2();
var teamsAfterDelete = await service.FindAllTeams();
Console.WriteLine(service.PrintTeams(teamsAfterDelete));

//TPC
var referees = EmployeeCreator.CreateReferees(RefereeCount);
EmployeeService employeeService = new EmployeeService(dbcontext);
await employeeService.AddReferees(referees.ToList());
Console.WriteLine(employeeService.PrintReferees(referees.ToList()));
try
{
    await employeeService.DeleteEmployees(4);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    referees = await employeeService.FindAllReferess();
    Console.WriteLine(employeeService.PrintReferees(referees.ToList()));

    //TPT
    var games = GameCreator.CreateFootballGames(GameCount);
    GameService gameService = new GameService(dbcontext);
    await gameService.AddGames(games);
    Console.WriteLine(gameService.PrintGames(games.ToList()));
    try
    {
        await gameService.DeleteAllFootballGames();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
