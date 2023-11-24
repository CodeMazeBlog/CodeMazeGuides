using EFCoreBulkUpdate.Model;

namespace EFCoreBulkUpdate.Creator
{
    public static class EmployeeCreator
    {
        public static IEnumerable<Referee> CreateReferees(int refereesCount)
        {
            return Enumerable.Range(1, refereesCount)
                .Select(j => new Referee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"Name {j}",
                    LastName = $"Last Name {j}",
                    LicenceNo = new Random().Next(60054, 70000).ToString(),
                    Category = string.Format("Category {0}", j.ToString()),
                    RefereeCode = new Random().Next(10000, 20000).ToString(),
                    YearsExperience = new Random().Next(1, 10),
                });
        }

        public static IEnumerable<Organizer> CreateOrganizers(int organizerCount)
        {
            return Enumerable.Range(1, organizerCount)
                .Select(j => new Organizer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"Name {j}",
                    LastName = $"Last Name {j}",
                    NoOfEventsOrganized = j,
                    OrganizerCode = new Random().Next(40000, 50000).ToString(),
                    YearsExperience = new Random().Next(1, 10),
                });
        }
    }
}
