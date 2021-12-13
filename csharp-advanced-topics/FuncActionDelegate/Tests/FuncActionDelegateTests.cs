using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FuncActionDelegateTests
    {
        public class Candidate
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Experience { get; set; }
        }

        private static bool CheckExperience(Candidate candidate)
        {
            return candidate.Experience >= 3;
        }

        private static bool CheckAge(Candidate candidate)
        {
            return candidate.Age < 40;
        }

        private static void DisplayScore(Candidate candidate, int score)
        {
            Console.WriteLine($"{candidate.Name}'s score is {score}");
        }

        [TestMethod]
        public void whenActionDelegate_DelegateInvocationListNotEmpty()
        {
            Action<Candidate,int> executeDisplayScoreAction = DisplayScore;
            var invocationList = executeDisplayScoreAction.GetInvocationList();
            Assert.AreEqual(invocationList.Length,1);
        }

        [TestMethod]
        public void whenFuncDelegate_DelegateInvocationListNotEmpty()
        {
            Func<Candidate, bool> checkAgeFunc = CheckAge;
            Func<Candidate, bool> checkExperienceFunc = CheckExperience;
            
            var invocationList1 = checkAgeFunc.GetInvocationList();
            var invocationList2 = checkExperienceFunc.GetInvocationList();

            Assert.AreEqual(invocationList1.Length, 1);
            Assert.AreEqual(invocationList2.Length, 1);
        }

        [TestMethod]
        public void whenActionDelegate_DelegateExecutesTheReferenceMethod()
        {
            var candidate = new Candidate { Name = "David", Age = 20, Experience = 5 };
            Action<Candidate, int> executeDisplayScoreAction= DisplayScore;

            try
            {
                executeDisplayScoreAction(candidate, 10);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void givenCandidate_whenFuncDelegates_DelegateDisplayScore()
        {
            var candidate = new Candidate { Name = "David", Age = 20, Experience = 5 };
            var checkFuncDelegates = new List<Func<Candidate, bool>> { CheckAge, CheckExperience };
            int score = 0;

            foreach (var check in checkFuncDelegates)
            {
                if (check(candidate))
                {
                    score += 5;
                }
            }

            Assert.AreEqual(score,10);
        }
    }
}