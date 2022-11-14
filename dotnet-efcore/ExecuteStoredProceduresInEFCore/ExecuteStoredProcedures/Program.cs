using ExecuteStoredProceduresInEFCore.Models;
using ExecuteStoredProceduresInEFCore;

using (var context = new AppDbContext())
{
    await SeedManager.SeedData(context);
}