using System;
using DelegateFuncActionConsole;
using Xunit;

namespace DelegateFuncction.Test
{
    public class ProcessUserInformationTest
    {
        private readonly UserModel _youngUser = null;
        private readonly UserModel _adult = null;

        public ProcessUserInformationTest()
        {
            _youngUser = new UserModel()
            {
                Name = "Henry",
                Age = 4
            };

            _adult = new UserModel()
            {
                Name = "Carl Johnson",
                Age = 30
            };
        }

        [Fact]
        [Trait("Category", "Delegate")]
        public void WelcomeUserToTheVotingSystem_GivenUserAndDelegates_WhenUserCannotVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystem(_youngUser, (age) => age > 18);
            var expected = $"Sorry {_youngUser.Name}, you are not allowed to vote at {_youngUser.Age} years old";
            Assert.Equal(actual, expected);
        }

        [Fact]
        [Trait("Category", "Delegate")]
        public void WelcomeUserToTheVotingSystem_GivenUserAndDelegates_WhenUserCanVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystem(_adult, (age) => age > 18);
            var expected = $"Welcome to the voting system {_adult.Name}, we hope you vote the right Candidate";
            ;
            Assert.Equal(actual, expected);
        }

        [Fact]
        [Trait("Category", "Func")]
        public void WelcomeUserToTheVotingSystemFunc_GivenUserAndFunc_WhenUserCanVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystemFunc(_adult, (age) => age > 18,
                (canUserVote, username, age) =>
                {
                    if (canUserVote)
                    {
                        return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
                    }

                    return $"Sorry {username}, you are not allowed to vote at {age} years old";
                });

            var expected = $"Welcome to the voting system {_adult.Name}, we hope you vote the right Candidate";
            ;
            Assert.Equal(actual, expected);
        }

        [Fact]
        [Trait("Category", "Func")]
        public void WWelcomeUserToTheVotingSystemFunc_GivenUserAndFunc_WhenUserCannotVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystemFunc(_youngUser, (age) => age > 18,
                (canUserVote, username, age) =>
                {
                    if (canUserVote)
                    {
                        return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
                    }

                    return $"Sorry {username}, you are not allowed to vote at {age} years old";
                });

            var expected = $"Sorry {_youngUser.Name}, you are not allowed to vote at {_youngUser.Age} years old";
            Assert.Equal(actual, expected);
        }
        
        [Fact]
        [Trait("Category", "Action")]
        public void WelcomeUserToTheVotingSystemFuncAndAction_GivenUserAndAction_WhenUserCannotVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystemFuncAndAction(_youngUser, (age) => age > 18,
                (canUserVote, username, age) =>
                {
                    if (canUserVote)
                    {
                        return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
                    }

                    return $"Sorry {username}, you are not allowed to vote at {age} years old";
                }, Console.WriteLine);

            var expected = $"Sorry {_youngUser.Name}, you are not allowed to vote at {_youngUser.Age} years old";
            Assert.Equal(actual, expected);
        }
        
        [Fact]
        [Trait("Category", "Action")]
        public void WelcomeUserToTheVotingSystemFuncAndAction_GivenUserAndAction_WhenUserCanVote_ThenReturnString()
        {
            var actual = ProcessUserInformation.WelcomeUserToTheVotingSystemFuncAndAction(_adult, (age) => age > 18,
                (canUserVote, username, age) =>
                {
                    if (canUserVote)
                    {
                        return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
                    }

                    return $"Sorry {username}, you are not allowed to vote at {age} years old";
                }, Console.WriteLine);

            var expected = $"Welcome to the voting system {_adult.Name}, we hope you vote the right Candidate";
            Assert.Equal(actual, expected);
        }
    }
}