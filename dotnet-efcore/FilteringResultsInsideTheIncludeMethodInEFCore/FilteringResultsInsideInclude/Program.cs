using FilteringResultsInsideInclude.Models;
using FilteringResultsInsideInclude;

using (var context = new AppDbContext())
{
    await Queries.SeedData(context);
}