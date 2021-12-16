// See https://aka.ms/new-console-template for more information

using System;
using DelegateFuncActionConsole;

var users = ProcessUserInformation.PopulateUsers();

foreach (var user in users)
{
   var message = ProcessUserInformation.WelcomeUserToTheVotingSystemFuncAndAction(user, IsUserAllowedToVote, (canUserVote, username, age) =>
   {
      if (canUserVote)
      {
         return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
      }
      return $"Sorry {username}, you are not allowed to vote at {age} years old";
   },NewUserAlert);
   
   Console.WriteLine(message);
}

Console.ReadLine();

bool IsUserAllowedToVote(int age)
{
   return age > 18;
}

string VotingMessage(bool canUserVote, string username, int age)
{
   if (canUserVote)
   {
      return $"Welcome to the voting system {username}, we hope you vote the right Candidate";
   }

   return $"Sorry {username}, you are not allowed to vote at {age} years old";
}

void NewUserAlert(string message)
{
   Console.WriteLine(message);
}



