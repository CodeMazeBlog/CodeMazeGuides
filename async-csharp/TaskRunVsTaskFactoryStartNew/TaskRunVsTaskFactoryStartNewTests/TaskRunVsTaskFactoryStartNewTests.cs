using System;
using System.IO;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskRunVsTaskFactoryStartNewTests
{
    public class TaskRunVsTaskFactoryStartNewUnitTest : IDisposable
    {
        readonly StringWriter strOut = new();
        readonly string NewLine = Environment.NewLine;

        public TaskRunVsTaskFactoryStartNewUnitTest()
        {
            Console.SetOut(strOut);
        }

        void DoWork(int order, int durationMs)
        {
            Thread.Sleep(durationMs);
            Console.WriteLine($"Task {order} executed");
        }

        [Fact]
        public void GivenWorkerMethods_WhenInvokedByTaskRun_ThenExecuteAsynchronously()
        {
            var task1 = Task.Run(() => DoWork(1, 500));
            var task2 = Task.Run(() => DoWork(2, 200));
            var task3 = Task.Run(() => DoWork(3, 300));

            Task.WaitAll(task1, task2, task3);

            // Output:
            // Task 2 executed
            // Task 3 executed
            // Task 1 executed

            var actualOutput = strOut.ToString();
            Assert.Equal($"Task 2 executed{NewLine}Task 3 executed{NewLine}Task 1 executed{NewLine}", actualOutput);
        }

        [Fact]
        public void GivenWorkerMethods_WhenInvokedByStartNew_ThenExecuteAsynchronously()
        {
            var task1 = Task.Factory.StartNew(() => DoWork(1, 500));
            var task2 = Task.Factory.StartNew(() => DoWork(2, 200));
            var task3 = Task.Factory.StartNew(() => DoWork(3, 300));

            Task.WaitAll(task1, task2, task3);

            // Output:
            // Task 2 executed
            // Task 3 executed
            // Task 1 executed

            var actualOutput = strOut.ToString();
            Assert.Equal($"Task 2 executed{NewLine}Task 3 executed{NewLine}Task 1 executed{NewLine}", actualOutput);
        }

        [Fact]
        public void GivenParentTask_WhenInvokedByStartNew_ThenShouldWaitForCompletionOfChildTask()
        {
            var outerTask = Task.Factory.StartNew(() =>
            {
                var innerTask = new Task(() =>
                {
                    Thread.Sleep(300);
                    Console.WriteLine("Inner task executed");
                }, TaskCreationOptions.AttachedToParent);
                innerTask.Start();

                Console.WriteLine("Outer task executed");
            });
            outerTask.Wait();
            Console.WriteLine("Main thread exiting");

            // Output:
            // Outer task executed
            // Inner task executed
            // Main thread exiting

            var actualOutput = strOut.ToString();
            Assert.Equal($"Outer task executed{NewLine}Inner task executed{NewLine}Main thread exiting{NewLine}", actualOutput);
        }

        [Fact]
        public void GivenParentTask_WhenInvokedByRun_ThenShouldNotWaitForCompletionOfChildTask()
        {
            var outerTask = Task.Run(() =>
            {
                var innerTask = new Task(() =>
                {
                    Thread.Sleep(300);
                    Console.WriteLine("Inner task executed");
                }, TaskCreationOptions.AttachedToParent);
                innerTask.Start();

                Console.WriteLine("Outer task executed");
            });
            outerTask.Wait();
            Console.WriteLine("Main thread exiting");

            // Output:
            // Outer task executed
            // Main thread exiting

            var actualOutput = strOut.ToString();
            Assert.Equal($"Outer task executed{NewLine}Main thread exiting{NewLine}", actualOutput);
        }

        [Fact]
        public void GivenAsyncDelegate_WhenInvokedByStartNew_ThenRequireCallingUnwrap()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);
                return "Calculated Value";
            });

            Console.WriteLine(task.GetType());      // System.Threading.Tasks.Task`1[System.Threading.Tasks.Task`1[System.String]]

            var innerTask = task.Unwrap();
            Console.WriteLine(innerTask.GetType()); // System.Threading.Tasks.UnwrapPromise`1[System.String]

            Console.WriteLine(innerTask.Result); 	// Calculated Value

            Assert.IsType<Task<Task<string>>>(task);
            Assert.IsAssignableFrom<Task<string>>(innerTask);
            Assert.Equal("Calculated Value", innerTask.Result);
        }


        [Fact]
        public void GivenAsyncDelegate_WhenInvokedByRun_ThenDoesNotRequireCallingUnwrap()
        {
            var task = Task.Run(async () =>
            {
                await Task.Delay(500);
                return "Calculated Value";
            });

            Console.WriteLine(task.GetType());  // System.Threading.Tasks.UnwrapPromise`1[System.String]

            Console.WriteLine(task.Result); 	// Calculated Value

            Assert.IsAssignableFrom<Task<string>>(task);
            Assert.Equal("Calculated Value", task.Result);
        }

        [Fact]
        public void GivenTasks_WhenInvokedWithOuterScopedVariable_ThenAreVulnerableToStateMutation()
        {
            var tasks = new List<Task>();
            for (var i = 1; i < 4; i++)
            {
                var task = Task.Run(async () =>
                {
                    await Task.Delay(100);
                    Console.WriteLine($"Iteration {i}");
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Output:
            // Iteration 4
            // Iteration 4
            // Iteration 4

            var actualOutput = strOut.ToString();
            Assert.Equal($"Iteration 4{NewLine}Iteration 4{NewLine}Iteration 4{NewLine}", actualOutput);
        }

        [Fact]
        public void GivenTasks_WhenInvokedWithLocalScopedVariable_ThenAreSafeFromStateMutation()
        {
            var tasks = new List<Task>();
            for (var i = 1; i < 4; i++)
            {
                var iteration = i;
                var task = Task.Run(async () =>
                {
                    await Task.Delay(100);
                    Console.WriteLine($"Iteration {iteration}");
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Approximate Output:
            // Iteration 3
            // Iteration 1
            // Iteration 2

            var actualOutput = strOut.ToString();
            Assert.Contains(new[]
            {
                $"Iteration 1{NewLine}Iteration 2{NewLine}Iteration 3{NewLine}",
                $"Iteration 1{NewLine}Iteration 3{NewLine}Iteration 2{NewLine}",
                $"Iteration 2{NewLine}Iteration 1{NewLine}Iteration 3{NewLine}",
                $"Iteration 2{NewLine}Iteration 3{NewLine}Iteration 1{NewLine}",
                $"Iteration 3{NewLine}Iteration 1{NewLine}Iteration 2{NewLine}",
                $"Iteration 3{NewLine}Iteration 2{NewLine}Iteration 1{NewLine}"
            }, e => e == actualOutput);
        }

        [Fact]
        public void GivenTasks_WhenInvokedByStartNewWithStateParameter_ThenAreSafeFromStateMutation()
        {
            var tasks = new List<Task>();
            for (var i = 1; i < 4; i++)
            {
                var task = Task.Factory.StartNew(async (iteration) =>
                {
                    await Task.Delay(100);
                    Console.WriteLine($"Iteration {iteration}");
                }, i)
                .Unwrap();

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Approximate Output:
            // Iteration 1
            // Iteration 3
            // Iteration 2

            var actualOutput = strOut.ToString();
            Assert.Contains(new[]
            {
                $"Iteration 1{NewLine}Iteration 2{NewLine}Iteration 3{NewLine}",
                $"Iteration 1{NewLine}Iteration 3{NewLine}Iteration 2{NewLine}",
                $"Iteration 2{NewLine}Iteration 1{NewLine}Iteration 3{NewLine}",
                $"Iteration 2{NewLine}Iteration 3{NewLine}Iteration 1{NewLine}",
                $"Iteration 3{NewLine}Iteration 1{NewLine}Iteration 2{NewLine}",
                $"Iteration 3{NewLine}Iteration 2{NewLine}Iteration 1{NewLine}"
            }, e => e == actualOutput);
        }

        public void Dispose()
        {
            strOut.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}