using ActionAndFuncDelegatesInCSharp;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using UsersManagerLib;
using static System.Collections.Specialized.BitVector32;

namespace Test
{


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static void Method1()
        {

        }

        [Test]
        public void ActionDelegate_WhenExplicitlyInitiateWhenInvoke_ShouldNotThrowException()
        {
            Action action = new Action(() =>
            {
                //some actions
            });
            action.Should().NotThrow();
        }

        [Test]
        public void ActionDelegate_WhenAssignWithMethodWhenInvoke_ShouldNotThrowException()
        {
            Action action = Method1;
            action.Should().NotThrow();
        }

        [Test]

        public void ActionDelegate_WhenAssignWithAnonymousMethod_ShouldNotThrowException()
        {
            Action action = delegate ()
            {
                //some actions
            };
            action.Should().NotThrow();
        }

        [Test]
        public void ActionDelegate_WhenAssignUsinglambda_ShouldNotThrowException()
        {
            Action action = () =>
            {
                //some actions
            };
            action.Should().NotThrow();
        }

        [Test]
        public void ActionDelegate_WhenIsNullWhenUseConditionalOperatorWhenCallWithInvoke_ShouldNotThrowException()
        {
            void CallAction()
            {
                Action action = null;
                action?.Invoke();
            }

            Action action = () =>
            {
                CallAction();
            };

            action.Should().NotThrow();
        }

        [Test]
        public void ActionDelegate_WhenIsNullWhenCallWithoutInvoke_ShouldThrowException()
        {
            void CallAction()
            {
                Action action = null;
                action();
            }

            Action action = () =>
            {
                CallAction();
            };

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void List_WhenQueryForUserWithId_ReturnsIEnumerableWithOneItemAndIdEqualToOne()
        {
            var users = new List<User>() {
                new User(){Id=1,Name="Name1"},
                new User(){Id=2,Name="Name2"},
                new User(){Id=3,Name="Name3"},
            };

            var usersById = users.Where(new Func<User, bool>((user) => user.Id == 1));
            Assert.That(usersById.Count(), Is.EqualTo(expected: 1));
            Assert.That(usersById.ElementAt(0).Id, Is.EqualTo(1));

            usersById = users.Where(user => user.Id == 1);
            Assert.That(usersById.Count(), Is.EqualTo(expected: 1));
            Assert.That(usersById.ElementAt(0).Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenUsersList_WhenIdIs1_ReturnsListWithOneUser()
        {
            var usersMng = new UsersManager()
            {
                Users = new List<User>() {
                            new User(){Id=1,Name="Name1"},
                            new User(){Id=2,Name="Name2"},
                            new User(){Id=3,Name="Name3"},
                        }
            };

            var filteredUsersUsingExplicitConstraint = usersMng.GetUsers(new Func<User, bool>((user) => user.Id == 1));
            var filteredUsersUsingLambda = usersMng.GetUsers(((user) => user.Id == 1));

            Assert.AreEqual(1, filteredUsersUsingExplicitConstraint.Count());
            Assert.AreEqual(1, filteredUsersUsingLambda.Count());
        }

        [Test]
        public void GivenNewUsersManager_WhenAddUserWithNameWhichViolatesRule_ReturnsEmptyList()
        {
            var userMgr = new UsersManager();
            userMgr.AddUser(new User() { Id = 2, Name = "name2" });
            Assert.AreEqual(0, userMgr.GetUsers(user => true).Count());
        }
    }
}