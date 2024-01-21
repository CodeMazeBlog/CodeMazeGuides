using SelectMultipleRecordsUsingLinqCSharp;

const int RecordCount = 10000;
const int SelectCount = 10;

await using var dbContext = new CompanyDbContext();
dbContext.Database.EnsureCreated();
dbContext.AddSeedData(RecordCount);

var random = new Random();

var idList = new List<int>();
var idHashSet = new HashSet<int>();

for (var cnt = 0; cnt < SelectCount; cnt++)
{
    var id = random.Next(1, RecordCount);
    idList.Add(id);
    idHashSet.Add(id);
}

var employeeRepository = new EmployeeRepository(dbContext);

var employees = employeeRepository.GetEmployeesUsingWhere(idList);
employees = employeeRepository.GetEmployeesUsingWhere(idHashSet);

employees = employeeRepository.GetEmployeesUsingJoin(idList);
employees = employeeRepository.GetEmployeesUsingJoin(idHashSet);

dbContext.Database.EnsureDeleted();
