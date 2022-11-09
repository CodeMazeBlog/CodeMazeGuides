using ExecuteStoredProceduresInEFCore.Models;
using ExecuteStoredProceduresInEFCore;

using (var context = new AppDbContext())
{
    await Methods.SeedData(context);
}