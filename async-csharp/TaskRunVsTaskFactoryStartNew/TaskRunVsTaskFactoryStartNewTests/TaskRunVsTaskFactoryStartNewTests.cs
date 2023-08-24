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
        private readonly StringWriter _strOut = new();
        private readonly string _newLine = Environment.NewLine;

        public TaskRunVsTaskFactoryStartNewUnitTest()
        {
            Console.SetOut(_strOut);
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

            var actualOutput = _strOut.ToString();
            Assert.Contains(new[]
            {
                $"Task 1 executed{_newLine}Task 2 executed{_newLine}Task 3 executed{_newLine}",
                $"Task 1 executed{_newLine}Task 3 executed{_newLine}Task 2 executed{_newLine}",
                $"Task 2 executed{_newLine}Task 1 executed{_newLine}Task 3 executed{_newLine}",
                $"Task 2 executed{_newLine}Task 3 executed{_newLine}Task 1 executed{_newLine}",
                $"Task 3 executed{_newLine}Task 1 executed{_newLine}Task 2 executed{_newLine}",
                $"Task 3 executed{_newLine}Task 2 executed{_newLine}Task 1 executed{_newLine}"
            }, e => e == actualOutput);
        }

        [Fact]
        public void GivenWorkerMethods_WhenInvokedByStartNew_ThenExecuteAsynchronously()
        {
            var task1 = Task.Factory.StartNew(() => DoWork(1, 500));
            var task2 = Task.Factory.StartNew(() => DoWork(2, 200));
            var task3 = Task.Factory.StartNew(() => DoWork(3, 300));

            Task.WaitAll(task1, task2, task3);

            var actualOutput = _strOut.ToString();
            Assert.Contains(new[]
            {
                $"Task 1 executed{_newLine}Task 2 executed{_newLine}Task 3 executed{_newLine}",
                $"Task 1 executed{_newLine}Task 3 executed{_newLine}Task 2 executed{_newLine}",
                $"Task 2 executed{_newLine}Task 1 executed{_newLine}Task 3 executed{_newLine}",
                $"Task 2 executed{_newLine}Task 3 executed{_newLine}Task 1 executed{_newLine}",
                $"Task 3 executed{_newLine}Task 1 executed{_newLine}Task 2 executed{_newLine}",
                $"Task 3 executed{_newLine}Task 2 executed{_newLine}Task 1 executed{_newLine}"
            }, e => e == actualOutput);
        }

        [Fact]
        public void GivenParentTask_WhenInvokedByStartNew_ThenShouldWaitForCompletionOfChildTask()
        {
            Task? innerTask = null;

            var outerTask = Task.Factory.StartNew(() =>
            {
                innerTask = new Task(() =>
                {
                    Thread.Sleep(300);
                    Console.WriteLine("Inner task executed");
                }, TaskCreationOptions.AttachedToParent);

                innerTask.Start(TaskScheduler.Default);
                Console.WriteLine("Outer task executed");
            });

            outerTask.Wait();
            Console.WriteLine($"Inner task completed: {innerTask?.IsCompleted ?? false}");
            Console.WriteLine("Main thread exiting");

            var actualOutput = _strOut.ToString();
            Assert.Equal($"Outer task executed{_newLine}Inner task executed{_newLine}Inner task completed: True{_newLine}Main thread exiting{_newLine}", actualOutput);
        }

        [Fact]
        public void GivenParentTask_WhenInvokedByRun_ThenShouldNotWaitForCompletionOfChildTask()
        {
            Task? innerTask = null;

            var outerTask = Task.Run(() =>
            {
                innerTask = new Task(() =>
                {
                    Thread.Sleep(300);
                    Console.WriteLine("Inner task executed");
                }, TaskCreationOptions.AttachedToParent);

                innerTask.Start(TaskScheduler.Default);
                Console.WriteLine("Outer task executed");
            });

            outerTask.Wait();
            Console.WriteLine($"Inner task completed: {innerTask?.IsCompleted ?? false}");
            Console.WriteLine("Main thread exiting");

            var actualOutput = _strOut.ToString();
            Assert.Equal($"Outer task executed{_newLine}Inner task completed: False{_newLine}Main thread exiting{_newLine}", actualOutput);

            // Force completion to ensure proper dispose 
            innerTask?.Wait();
        }

        [Fact]
        public void GivenAsyncDelegate_WhenInvokedByStartNew_ThenRequireCallingUnwrap()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);
                return "Calculated Value";
            });

            Console.WriteLine(task.GetType()); // System.Threading.Tasks.Task`1[System.Threading.Tasks.Task`1[System.String]]

            var innerTask = task.Unwrap();
            Console.WriteLine(innerTask.GetType()); // System.Threading.Tasks.UnwrapPromise`1[System.String]
            Console.WriteLine(innerTask.Result); // Calculated Value

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

            Console.WriteLine(task.GetType()); // System.Threading.Tasks.UnwrapPromise`1[System.String]
            Console.WriteLine(task.Result); // Calculated Value

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

            var actualOutput = _strOut.ToString();
            Assert.Equal($"Iteration 4{_newLine}Iteration 4{_newLine}Iteration 4{_newLine}", actualOutput);
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

            var actualOutput = _strOut.ToString();
            Assert.Contains(new[]
            {
                $"Iteration 1{_newLine}Iteration 2{_newLine}Iteration 3{_newLine}",
                $"Iteration 1{_newLine}Iteration 3{_newLine}Iteration 2{_newLine}",
                $"Iteration 2{_newLine}Iteration 1{_newLine}Iteration 3{_newLine}",
                $"Iteration 2{_newLine}Iteration 3{_newLine}Iteration 1{_newLine}",
                $"Iteration 3{_newLine}Iteration 1{_newLine}Iteration 2{_newLine}",
                $"Iteration 3{_newLine}Iteration 2{_newLine}Iteration 1{_newLine}"
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

            var actualOutput = _strOut.ToString();
            Assert.Contains(new[]
            {
                $"Iteration 1{_newLine}Iteration 2{_newLine}Iteration 3{_newLine}",
                $"Iteration 1{_newLine}Iteration 3{_newLine}Iteration 2{_newLine}",
                $"Iteration 2{_newLine}Iteration 1{_newLine}Iteration 3{_newLine}",
                $"Iteration 2{_newLine}Iteration 3{_newLine}Iteration 1{_newLine}",
                $"Iteration 3{_newLine}Iteration 1{_newLine}Iteration 2{_newLine}",
                $"Iteration 3{_newLine}Iteration 2{_newLine}Iteration 1{_newLine}"
            }, e => e == actualOutput);
        }

        public void Dispose()
        {
            _strOut.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}