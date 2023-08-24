using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SplitEntityIntoDifferentTableMappings;

namespace SplitEntityUnitTests
{
    public class SplitEntityUnitTests
    {
        [Test]
        public void WhenCreatingANewEntity_ThenEntityIsSplitIntoTwoTables()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new UserContext(contextOptions);

            if (context.Database.EnsureCreated())
            {
                var user = new User(1, "John Doe", "john@doe.com", true, "Classic");
                context.Add(user);
                context.SaveChanges();

                user = context.Users.Single();

                var name = context.Database.SqlQuery<string>($"select Name from Users")
                    .ToList();

                var theme = context.Database.SqlQuery<string>($"select Theme from UserSettings")
                    .ToList();

                Assert.That(name.Count(), Is.EqualTo(1));
                Assert.That(theme.Count(), Is.EqualTo(1));
                Assert.That(name.ElementAt(0), Is.EqualTo("John Doe"));
                Assert.That(theme.ElementAt(0), Is.EqualTo("Classic"));
            }
        }

        [Test]
        public void WhenUpdatingAnEntity_ThenOnlyOneTableIsUpdated()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new UserContext(contextOptions);

            if (context.Database.EnsureCreated())
            {
                context.Add(new User(1, "John Doe", "john@doe.com", true, "Classic"));
                context.SaveChanges();

                var user = context.Users.Single();
                user.Theme = "Flashy";
                context.SaveChanges();

                var name = context.Database.SqlQuery<string>($"select Name from Users")
                    .ToList();

                var theme = context.Database.SqlQuery<string>($"select Theme from UserSettings")
                    .ToList();

                Assert.That(name.Count(), Is.EqualTo(1));
                Assert.That(theme.Count(), Is.EqualTo(1));
                Assert.That(name.ElementAt(0), Is.EqualTo("John Doe"));
                Assert.That(theme.ElementAt(0), Is.EqualTo("Flashy"));
            }
        }

        [Test]
        public void WhenDeletingAnEntity_ThenRowsAreDeletedFromBothTables()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new UserContext(contextOptions);

            if (context.Database.EnsureCreated())
            {
                context.Add(new User(1, "John Doe", "john@doe.com", true, "Classic"));
                context.SaveChanges();

                var user = context.Users.Single();
                context.Users.Remove(user);
                context.SaveChanges();

                var name = context.Database.SqlQuery<string>($"select Name from Users")
                    .ToList();

                var theme = context.Database.SqlQuery<string>($"select Theme from UserSettings")
                    .ToList();

                Assert.That(name.Count(), Is.EqualTo(0));
                Assert.That(theme.Count(), Is.EqualTo(0));
            }
        }
    }
}