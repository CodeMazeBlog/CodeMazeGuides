using System;
using System.Collections.Generic;

namespace DelegateFuncActionConsole
{
    public static class ProcessUserInformation
    {
        public static List<UserModel> PopulateUsers()
        {
            return new List<UserModel>()
            {
               new UserModel()
               {
                   Age = 19,
                   Name = "David"
               },
               new UserModel()
               {
                   Name = "Paul",
                   Age=24
               },
               new UserModel()
               {
                   Name = "Mark",
                   Age = 14
               }
            };
        }

        public delegate bool AgeConfirmationDelegate(int age);

        public static string WelcomeUserToTheVotingSystem(UserModel user, AgeConfirmationDelegate ageConfirmationDelegate)
        {
            if (ageConfirmationDelegate(user.Age))
            {
                return $"Welcome to the voting system {user.Name}, we hope you vote the right Candidate";
            }

            return $"Sorry {user.Name}, you are not allowed to vote at {user.Age} years old";
        }

        public static string WelcomeUserToTheVotingSystemFunc(UserModel user,
            AgeConfirmationDelegate ageConfirmationDelegate,
            Func<bool, string, int, string> sendUserAMessage)
        {
            var canUserVote = ageConfirmationDelegate(user.Age);
            return sendUserAMessage(canUserVote, user.Name, user.Age);
        }
        
        public static string WelcomeUserToTheVotingSystemFuncAndAction(UserModel user,
            AgeConfirmationDelegate ageConfirmationDelegate,
            Func<bool, string, int, string> sendUserAMessage, Action<string> alertUser)
        {
            alertUser($"we have a new user! -  Hi {user.Name}");
            var canUserVote = ageConfirmationDelegate(user.Age);
            return sendUserAMessage(canUserVote, user.Name, user.Age);
        }
    }
}