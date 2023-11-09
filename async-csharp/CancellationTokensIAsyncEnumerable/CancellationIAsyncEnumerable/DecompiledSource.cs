// Decompiled with JetBrains decompiler
// Type: CancellationIAsyncEnumerable.Program
// Assembly: CancellationIAsyncEnumerable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF05069-EAE8-440E-A4B5-2A5B286C3BE9
// Assembly location: C:\Users\0156044\source\repos\dbeti\CodeMazeGuides\csharp-advanced-topics\CancellationTokensIAsyncEnumerable\CancellationIAsyncEnumerable\CancellationIAsyncEnumerable\bin\Debug\netcoreapp3.1\CancellationIAsyncEnumerable.dll
// Compiler-generated code is shown

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace CancellationIAsyncEnumerable
{
    internal class Program
    {
        [AsyncStateMachine(typeof(Program.\u003CMain\u003Ed__0))]
        [DebuggerStepThrough]
        private static Task Main(string[] args)
        {
            Program.\u003CMain\u003Ed__0 stateMachine = new Program.\u003CMain\u003Ed__0();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.args = args;
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CMain\u003Ed__0 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        [AsyncStateMachine(typeof(Program.\u003CCompilerGeneratingExample\u003Ed__1))]
        [DebuggerStepThrough]
        private static Task CompilerGeneratingExample()
        {
            Program.\u003CCompilerGeneratingExample\u003Ed__1 stateMachine = new Program.\u003CCompilerGeneratingExample\u003Ed__1();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CCompilerGeneratingExample\u003Ed__1 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        [AsyncStateMachine(typeof(Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2))]
        [DebuggerStepThrough]
        public static Task CancelledIndefiniteEnumerationExample()
        {
            Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2 stateMachine = new Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        [AsyncStateMachine(typeof(Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3))]
        [DebuggerStepThrough]
        public static Task NotCancelledIndefiniteEnumerationWithCancellationExample()
        {
            Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3 stateMachine = new Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        [AsyncStateMachine(typeof(Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4))]
        [DebuggerStepThrough]
        public static Task CancelledIndefiniteEnumerationWithCancellationExample()
        {
            Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4 stateMachine = new Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        private static IAsyncEnumerable<int> GetIndefinitelyRunningRangeWrapperAsync()
        {
            return Program.GetIndefinitelyRunningRangeAsync(new System.Threading.CancellationToken());
        }

        [AsyncIteratorStateMachine(typeof(Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6))]
        private static IAsyncEnumerable<int> GetIndefinitelyRunningRangeAsync(
          [EnumeratorCancellation] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 runningRangeAsyncD6 = new Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6(-2);
            runningRangeAsyncD6.\u003C\u003E3__cancellationToken = cancellationToken;
            return (IAsyncEnumerable<int>)runningRangeAsyncD6;
        }

        [AsyncStateMachine(typeof(Program.\u003CIndefinitelyRunningTask\u003Ed__7))]
        [DebuggerStepThrough]
        private Task IndefinitelyRunningTask(CancellationToken cancellationToken)
        {
            Program.\u003CIndefinitelyRunningTask\u003Ed__7 stateMachine = new Program.\u003CIndefinitelyRunningTask\u003Ed__7();
            stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.\u003C\u003E4__this = this;
            stateMachine.cancellationToken = cancellationToken;
            stateMachine.\u003C\u003E1__state = -1;
            stateMachine.\u003C\u003Et__builder.Start < Program.\u003CIndefinitelyRunningTask\u003Ed__7 > (ref stateMachine);
            return stateMachine.\u003C\u003Et__builder.Task;
        }

        public Program()
        {
            base.\u002Ector();
        }

        [DebuggerStepThrough]
        [SpecialName]
        private static void \u003CMain\u003E(string[] args)
    {
      Program.Main(args).GetAwaiter().GetResult();
    }

    [AsyncIteratorStateMachine(typeof(Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed))]
    [CompilerGenerated]
    internal static IAsyncEnumerable<int> \u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0(
      System.Threading.CancellationToken cancellationToken)
    {
      Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed runningRangeAsync20D = new Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed(-2);
    runningRangeAsync20D.\u003C\u003E3__cancellationToken = cancellationToken;
      return (IAsyncEnumerable<int>) runningRangeAsync20D;
}

[AsyncIteratorStateMachine(typeof(Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed))]
[CompilerGenerated]
internal static IAsyncEnumerable<int> \u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0(
  System.Threading.CancellationToken cancellationToken)
    {
    Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed runningRangeAsync30D = new Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed(-2);
    runningRangeAsync30D.\u003C\u003E3__cancellationToken = cancellationToken;
    return (IAsyncEnumerable<int>)runningRangeAsync30D;
}

[CompilerGenerated]
internal static IAsyncEnumerable<int> \u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeWrapperAsync\u007C3_1()
    {
    return Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0(new System.Threading.CancellationToken());
}

[CompilerGenerated]
private sealed class \u003CMain\u003Ed__0: IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
public AsyncTaskMethodBuilder \u003C\u003Et__builder;
public string[] args;
private TaskAwaiter \u003C\u003Eu__1;

public \u003CMain\u003Ed__0()
      {
    base.\u002Ector();
}

void IAsyncStateMachine.MoveNext()
{
    int num1 = this.\u003C\u003E1__state;
    try
    {
        TaskAwaiter awaiter1;
        int num2;
        TaskAwaiter awaiter2;
        TaskAwaiter awaiter3;
        TaskAwaiter awaiter4;
        switch (num1)
        {
            case 0:
                awaiter1 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new TaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
                break;
            case 1:
                awaiter2 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new TaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
                goto label_8;
            case 2:
                awaiter3 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new TaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
                goto label_11;
            case 3:
                awaiter4 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new TaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
                goto label_14;
            default:
                awaiter1 = Program.CompilerGeneratingExample().GetAwaiter();
                if (!awaiter1.IsCompleted)
                {
                    this.\u003C\u003E1__state = num2 = 0;
                    this.\u003C\u003Eu__1 = awaiter1;
                    Program.\u003CMain\u003Ed__0 stateMachine = this;
                    this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted < TaskAwaiter, Program.\u003CMain\u003Ed__0>(ref awaiter1, ref stateMachine);
                return;
              }
              break;
          }
          awaiter1.GetResult();
          awaiter2 = Program.CancelledIndefiniteEnumerationExample().GetAwaiter();
          if (!awaiter2.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 1;
            this.\u003C\u003Eu__1 = awaiter2;
            Program.\u003CMain\u003Ed__0 stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003CMain\u003Ed__0>(ref awaiter2, ref stateMachine);
            return;
          }
label_8:
          awaiter2.GetResult();
          awaiter3 = Program.NotCancelledIndefiniteEnumerationWithCancellationExample().GetAwaiter();
          if (!awaiter3.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 2;
            this.\u003C\u003Eu__1 = awaiter3;
            Program.\u003CMain\u003Ed__0 stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003CMain\u003Ed__0>(ref awaiter3, ref stateMachine);
            return;
          }
label_11:
          awaiter3.GetResult();
          awaiter4 = Program.CancelledIndefiniteEnumerationWithCancellationExample().GetAwaiter();
          if (!awaiter4.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 3;
            this.\u003C\u003Eu__1 = awaiter4;
            Program.\u003CMain\u003Ed__0 stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003CMain\u003Ed__0>(ref awaiter4, ref stateMachine);
            return;
          }
label_14:
          awaiter4.GetResult();
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003C\u003Et__builder.SetException(ex);
          return;
        }
        this.\u003C\u003E1__state = -2;
        this.\u003C\u003Et__builder.SetResult();
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003CCompilerGeneratingExample\u003Ed__1 : IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncTaskMethodBuilder \u003C\u003Et__builder;
      private IAsyncEnumerable<int> \u003CindefinitelyRunningRange\u003E5__1;
      private IAsyncEnumerator<int> \u003Cenumerator\u003E5__2;
      private object \u003C\u003Es__3;
      private int \u003C\u003Es__4;
      private bool \u003C\u003Es__5;
      private ValueTaskAwaiter<bool> \u003C\u003Eu__1;
      private ValueTaskAwaiter \u003C\u003Eu__2;

      public \u003CCompilerGeneratingExample\u003Ed__1()
      {
        base.\u002Ector();
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          ValueTaskAwaiter awaiter1;
          switch (num1)
          {
            case 0:
              try
              {
                if (num1 == 0)
                  goto label_7;
label_5:
                ValueTaskAwaiter<bool> awaiter2 = this.\u003Cenumerator\u003E5__2.MoveNextAsync().GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 0;
                  this.\u003C\u003Eu__1 = awaiter2;
                  Program.\u003CCompilerGeneratingExample\u003Ed__1 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ValueTaskAwaiter<bool>, Program.\u003CCompilerGeneratingExample\u003Ed__1>(ref awaiter2, ref stateMachine);
                  return;
                }
                goto label_8;
label_7:
                awaiter2 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new ValueTaskAwaiter<bool>();
                this.\u003C\u003E1__state = num2 = -1;
label_8:
                this.\u003C\u003Es__5 = awaiter2.GetResult();
                if (this.\u003C\u003Es__5)
                  goto label_5;
              }
              catch (object ex)
              {
                this.\u003C\u003Es__3 = ex;
              }
              if (this.\u003Cenumerator\u003E5__2 != null)
              {
                awaiter1 = this.\u003Cenumerator\u003E5__2.DisposeAsync().GetAwaiter();
                if (!awaiter1.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 1;
                  this.\u003C\u003Eu__2 = awaiter1;
                  Program.\u003CCompilerGeneratingExample\u003Ed__1 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ValueTaskAwaiter, Program.\u003CCompilerGeneratingExample\u003Ed__1>(ref awaiter1, ref stateMachine);
                  return;
                }
                break;
              }
              goto label_15;
            case 1:
              awaiter1 = this.\u003C\u003Eu__2;
              this.\u003C\u003Eu__2 = new ValueTaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              this.\u003CindefinitelyRunningRange\u003E5__1 = Program.GetIndefinitelyRunningRangeAsync(new System.Threading.CancellationToken());
              this.\u003Cenumerator\u003E5__2 = this.\u003CindefinitelyRunningRange\u003E5__1.GetAsyncEnumerator(new System.Threading.CancellationToken());
              this.\u003C\u003Es__3 = (object) null;
              this.\u003C\u003Es__4 = 0;
              goto case 0;
          }
          awaiter1.GetResult();
label_15:
          object s3 = this.\u003C\u003Es__3;
          if (s3 != null)
          {
            if (!(s3 is Exception source4))
              throw s3;
            ExceptionDispatchInfo.Capture(source4).Throw();
          }
          int s4 = this.\u003C\u003Es__4;
          this.\u003C\u003Es__3 = (object) null;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003CindefinitelyRunningRange\u003E5__1 = (IAsyncEnumerable<int>) null;
          this.\u003Cenumerator\u003E5__2 = (IAsyncEnumerator<int>) null;
          this.\u003C\u003Et__builder.SetException(ex);
          return;
        }
        this.\u003C\u003E1__state = -2;
        this.\u003CindefinitelyRunningRange\u003E5__1 = (IAsyncEnumerable<int>) null;
        this.\u003Cenumerator\u003E5__2 = (IAsyncEnumerator<int>) null;
        this.\u003C\u003Et__builder.SetResult();
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003CCancelledIndefiniteEnumerationExample\u003Ed__2 : IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncTaskMethodBuilder \u003C\u003Et__builder;
      private CancellationTokenSource \u003CcancellationTokenSource\u003E5__1;
      private IAsyncEnumerable<int> \u003CindefinitelyRunningRange\u003E5__2;
      private IAsyncEnumerator<int> \u003C\u003Es__3;
      private object \u003C\u003Es__4;
      private int \u003C\u003Es__5;
      private int \u003Cindex\u003E5__6;
      private bool \u003C\u003Es__7;
      private ValueTaskAwaiter<bool> \u003C\u003Eu__1;
      private ValueTaskAwaiter \u003C\u003Eu__2;

      public \u003CCancelledIndefiniteEnumerationExample\u003Ed__2()
      {
        base.\u002Ector();
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          ValueTaskAwaiter awaiter1;
          switch (num1)
          {
            case 0:
              try
              {
                if (num1 == 0)
                  goto label_8;
label_6:
                ValueTaskAwaiter<bool> awaiter2 = this.\u003C\u003Es__3.MoveNextAsync().GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 0;
                  this.\u003C\u003Eu__1 = awaiter2;
                  Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ValueTaskAwaiter<bool>, Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2>(ref awaiter2, ref stateMachine);
                  return;
                }
                goto label_9;
label_8:
                awaiter2 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new ValueTaskAwaiter<bool>();
                this.\u003C\u003E1__state = num2 = -1;
label_9:
                this.\u003C\u003Es__7 = awaiter2.GetResult();
                if (this.\u003C\u003Es__7)
                {
                  this.\u003Cindex\u003E5__6 = this.\u003C\u003Es__3.Current;
                  goto label_6;
                }
              }
              catch (object ex)
              {
                this.\u003C\u003Es__4 = ex;
              }
              if (this.\u003C\u003Es__3 != null)
              {
                awaiter1 = this.\u003C\u003Es__3.DisposeAsync().GetAwaiter();
                if (!awaiter1.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 1;
                  this.\u003C\u003Eu__2 = awaiter1;
                  Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ValueTaskAwaiter, Program.\u003CCancelledIndefiniteEnumerationExample\u003Ed__2>(ref awaiter1, ref stateMachine);
                  return;
                }
                break;
              }
              goto label_16;
            case 1:
              awaiter1 = this.\u003C\u003Eu__2;
              this.\u003C\u003Eu__2 = new ValueTaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              this.\u003CcancellationTokenSource\u003E5__1 = new CancellationTokenSource();
              this.\u003CcancellationTokenSource\u003E5__1.CancelAfter(7000);
              this.\u003CindefinitelyRunningRange\u003E5__2 = Program.\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0(this.\u003CcancellationTokenSource\u003E5__1.Token);
              this.\u003C\u003Es__3 = this.\u003CindefinitelyRunningRange\u003E5__2.GetAsyncEnumerator(new System.Threading.CancellationToken());
              this.\u003C\u003Es__4 = (object) null;
              this.\u003C\u003Es__5 = 0;
              goto case 0;
          }
          awaiter1.GetResult();
label_16:
          object s4 = this.\u003C\u003Es__4;
          if (s4 != null)
          {
            if (!(s4 is Exception source4))
              throw s4;
            ExceptionDispatchInfo.Capture(source4).Throw();
          }
          int s5 = this.\u003C\u003Es__5;
          this.\u003C\u003Es__4 = (object) null;
          this.\u003C\u003Es__3 = (IAsyncEnumerator<int>) null;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
          this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
          this.\u003C\u003Et__builder.SetException(ex);
          return;
        }
        this.\u003C\u003E1__state = -2;
        this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
        this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
        this.\u003C\u003Et__builder.SetResult();
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3 : 
      IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncTaskMethodBuilder \u003C\u003Et__builder;
      private CancellationTokenSource \u003CcancellationTokenSource\u003E5__1;
      private IAsyncEnumerable<int> \u003CindefinitelyRunningRange\u003E5__2;
      private ConfiguredCancelableAsyncEnumerable<int>.Enumerator \u003C\u003Es__3;
      private object \u003C\u003Es__4;
      private int \u003C\u003Es__5;
      private int \u003Cindex\u003E5__6;
      private bool \u003C\u003Es__7;
      private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter \u003C\u003Eu__1;
      private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter \u003C\u003Eu__2;

      public \u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3()
      {
        base.\u002Ector();
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter1;
          switch (num1)
          {
            case 0:
              try
              {
                if (num1 == 0)
                  goto label_8;
label_6:
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2 = this.\u003C\u003Es__3.MoveNextAsync().GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 0;
                  this.\u003C\u003Eu__1 = awaiter2;
                  Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter, Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3>(ref awaiter2, ref stateMachine);
                  return;
                }
                goto label_9;
label_8:
                awaiter2 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
label_9:
                this.\u003C\u003Es__7 = awaiter2.GetResult();
                if (this.\u003C\u003Es__7)
                {
                  this.\u003Cindex\u003E5__6 = this.\u003C\u003Es__3.Current;
                  goto label_6;
                }
              }
              catch (object ex)
              {
                this.\u003C\u003Es__4 = ex;
              }
              awaiter1 = this.\u003C\u003Es__3.DisposeAsync().GetAwaiter();
              if (!awaiter1.IsCompleted)
              {
                this.\u003C\u003E1__state = num2 = 1;
                this.\u003C\u003Eu__2 = awaiter1;
                Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3 stateMachine = this;
                this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter, Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__3>(ref awaiter1, ref stateMachine);
                return;
              }
              break;
            case 1:
              awaiter1 = this.\u003C\u003Eu__2;
              this.\u003C\u003Eu__2 = new ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              this.\u003CcancellationTokenSource\u003E5__1 = new CancellationTokenSource();
              this.\u003CcancellationTokenSource\u003E5__1.CancelAfter(7000);
              this.\u003CindefinitelyRunningRange\u003E5__2 = Program.\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeWrapperAsync\u007C3_1();
              this.\u003C\u003Es__3 = this.\u003CindefinitelyRunningRange\u003E5__2.WithCancellation<int>(this.\u003CcancellationTokenSource\u003E5__1.Token).GetAsyncEnumerator();
              this.\u003C\u003Es__4 = (object) null;
              this.\u003C\u003Es__5 = 0;
              goto case 0;
          }
          awaiter1.GetResult();
          object s4 = this.\u003C\u003Es__4;
          if (s4 != null)
          {
            if (!(s4 is Exception source4))
              throw s4;
            ExceptionDispatchInfo.Capture(source4).Throw();
          }
          int s5 = this.\u003C\u003Es__5;
          this.\u003C\u003Es__4 = (object) null;
          this.\u003C\u003Es__3 = new ConfiguredCancelableAsyncEnumerable<int>.Enumerator();
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
          this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
          this.\u003C\u003Et__builder.SetException(ex);
          return;
        }
        this.\u003C\u003E1__state = -2;
        this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
        this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
        this.\u003C\u003Et__builder.SetResult();
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4 : 
      IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncTaskMethodBuilder \u003C\u003Et__builder;
      private CancellationTokenSource \u003CcancellationTokenSource\u003E5__1;
      private IAsyncEnumerable<int> \u003CindefinitelyRunningRange\u003E5__2;
      private ConfiguredCancelableAsyncEnumerable<int>.Enumerator \u003C\u003Es__3;
      private object \u003C\u003Es__4;
      private int \u003C\u003Es__5;
      private int \u003Cindex\u003E5__6;
      private bool \u003C\u003Es__7;
      private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter \u003C\u003Eu__1;
      private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter \u003C\u003Eu__2;

      public \u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4()
      {
        base.\u002Ector();
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter1;
          switch (num1)
          {
            case 0:
              try
              {
                if (num1 == 0)
                  goto label_8;
label_6:
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2 = this.\u003C\u003Es__3.MoveNextAsync().GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                  this.\u003C\u003E1__state = num2 = 0;
                  this.\u003C\u003Eu__1 = awaiter2;
                  Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4 stateMachine = this;
                  this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter, Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4>(ref awaiter2, ref stateMachine);
                  return;
                }
                goto label_9;
label_8:
                awaiter2 = this.\u003C\u003Eu__1;
                this.\u003C\u003Eu__1 = new ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter();
                this.\u003C\u003E1__state = num2 = -1;
label_9:
                this.\u003C\u003Es__7 = awaiter2.GetResult();
                if (this.\u003C\u003Es__7)
                {
                  this.\u003Cindex\u003E5__6 = this.\u003C\u003Es__3.Current;
                  goto label_6;
                }
              }
              catch (object ex)
              {
                this.\u003C\u003Es__4 = ex;
              }
              awaiter1 = this.\u003C\u003Es__3.DisposeAsync().GetAwaiter();
              if (!awaiter1.IsCompleted)
              {
                this.\u003C\u003E1__state = num2 = 1;
                this.\u003C\u003Eu__2 = awaiter1;
                Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4 stateMachine = this;
                this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter, Program.\u003CCancelledIndefiniteEnumerationWithCancellationExample\u003Ed__4>(ref awaiter1, ref stateMachine);
                return;
              }
              break;
            case 1:
              awaiter1 = this.\u003C\u003Eu__2;
              this.\u003C\u003Eu__2 = new ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              this.\u003CcancellationTokenSource\u003E5__1 = new CancellationTokenSource();
              this.\u003CcancellationTokenSource\u003E5__1.CancelAfter(7000);
              this.\u003CindefinitelyRunningRange\u003E5__2 = Program.GetIndefinitelyRunningRangeWrapperAsync();
              this.\u003C\u003Es__3 = this.\u003CindefinitelyRunningRange\u003E5__2.WithCancellation<int>(this.\u003CcancellationTokenSource\u003E5__1.Token).GetAsyncEnumerator();
              this.\u003C\u003Es__4 = (object) null;
              this.\u003C\u003Es__5 = 0;
              goto case 0;
          }
          awaiter1.GetResult();
          object s4 = this.\u003C\u003Es__4;
          if (s4 != null)
          {
            if (!(s4 is Exception source4))
              throw s4;
            ExceptionDispatchInfo.Capture(source4).Throw();
          }
          int s5 = this.\u003C\u003Es__5;
          this.\u003C\u003Es__4 = (object) null;
          this.\u003C\u003Es__3 = new ConfiguredCancelableAsyncEnumerable<int>.Enumerator();
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
          this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
          this.\u003C\u003Et__builder.SetException(ex);
          return;
        }
        this.\u003C\u003E1__state = -2;
        this.\u003CcancellationTokenSource\u003E5__1 = (CancellationTokenSource) null;
        this.\u003CindefinitelyRunningRange\u003E5__2 = (IAsyncEnumerable<int>) null;
        this.\u003C\u003Et__builder.SetResult();
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 : 
      IAsyncEnumerable<int>,
      IAsyncEnumerator<int>,
      IAsyncDisposable,
      IValueTaskSource<bool>,
      IValueTaskSource,
      IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncIteratorMethodBuilder \u003C\u003Et__builder;
      public ManualResetValueTaskSourceCore<bool> \u003C\u003Ev__promiseOfValueOrEnd;
      private int \u003C\u003E2__current;
      private bool \u003C\u003Ew__disposeMode;
      private CancellationTokenSource \u003C\u003Ex__combinedTokens;
      private int \u003C\u003El__initialThreadId;
      private System.Threading.CancellationToken cancellationToken;
      public System.Threading.CancellationToken \u003C\u003E3__cancellationToken;
      private int \u003Cindex\u003E5__1;
      private TaskAwaiter \u003C\u003Eu__1;

      [DebuggerHidden]
      public \u003CGetIndefinitelyRunningRangeAsync\u003Ed__6(int _param1)
      {
        base.\u002Ector();
        this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
        this.\u003C\u003E1__state = _param1;
        this.\u003C\u003El__initialThreadId = Environment.CurrentManagedThreadId;
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          TaskAwaiter awaiter;
          switch (num1)
          {
            case -4:
              this.\u003C\u003E1__state = num2 = -1;
              if (!this.\u003C\u003Ew__disposeMode)
                goto label_8;
              else
                goto label_12;
            case 0:
              awaiter = this.\u003C\u003Eu__1;
              this.\u003C\u003Eu__1 = new TaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              if (!this.\u003C\u003Ew__disposeMode)
              {
                this.\u003C\u003E1__state = num2 = -1;
                this.\u003Cindex\u003E5__1 = 0;
                goto label_8;
              }
              else
                goto label_12;
          }
label_6:
          awaiter.GetResult();
          this.\u003C\u003E2__current = this.\u003Cindex\u003E5__1++;
          this.\u003C\u003E1__state = num2 = -4;
          goto label_15;
label_8:
          awaiter = Task.Delay(5000, this.cancellationToken).GetAwaiter();
          if (!awaiter.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 0;
            this.\u003C\u003Eu__1 = awaiter;
            Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6>(ref awaiter, ref stateMachine);
            return;
          }
          goto label_6;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          if (this.\u003C\u003Ex__combinedTokens != null)
          {
            this.\u003C\u003Ex__combinedTokens.Dispose();
            this.\u003C\u003Ex__combinedTokens = (CancellationTokenSource) null;
          }
          this.\u003C\u003Et__builder.Complete();
          this.\u003C\u003Ev__promiseOfValueOrEnd.SetException(ex);
          return;
        }
label_12:
        this.\u003C\u003E1__state = -2;
        if (this.\u003C\u003Ex__combinedTokens != null)
        {
          this.\u003C\u003Ex__combinedTokens.Dispose();
          this.\u003C\u003Ex__combinedTokens = (CancellationTokenSource) null;
        }
        this.\u003C\u003Et__builder.Complete();
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(false);
        return;
label_15:
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(true);
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }

      [DebuggerHidden]
      IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(
        System.Threading.CancellationToken cancellationToken)
      {
        Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 runningRangeAsyncD6;
        if (this.\u003C\u003E1__state == -2 && this.\u003C\u003El__initialThreadId == Environment.CurrentManagedThreadId)
        {
          this.\u003C\u003E1__state = -3;
          this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
          this.\u003C\u003Ew__disposeMode = false;
          runningRangeAsyncD6 = this;
        }
        else
          runningRangeAsyncD6 = new Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6(-3);
        if (this.\u003C\u003E3__cancellationToken.Equals(new System.Threading.CancellationToken()))
          runningRangeAsyncD6.cancellationToken = cancellationToken;
        else if (cancellationToken.Equals(this.\u003C\u003E3__cancellationToken) || cancellationToken.Equals(new System.Threading.CancellationToken()))
        {
          runningRangeAsyncD6.cancellationToken = this.\u003C\u003E3__cancellationToken;
        }
        else
        {
          this.\u003C\u003Ex__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(this.\u003C\u003E3__cancellationToken, cancellationToken);
          runningRangeAsyncD6.cancellationToken = this.\u003C\u003Ex__combinedTokens.Token;
        }
        return (IAsyncEnumerator<int>) runningRangeAsyncD6;
      }

      [DebuggerHidden]
      ValueTask<bool> IAsyncEnumerator<int>.MoveNextAsync()
      {
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask<bool>();
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6>(ref stateMachine);
        short version = this.\u003C\u003Ev__promiseOfValueOrEnd.Version;
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded ? new ValueTask<bool>(this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(version)) : new ValueTask<bool>((IValueTaskSource<bool>) this, version);
      }

      int IAsyncEnumerator<int>.Current
      {
        [DebuggerHidden] get
        {
          return this.\u003C\u003E2__current;
        }
      }

      [DebuggerHidden]
      bool IValueTaskSource<bool>.GetResult(short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource<bool>.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      void IValueTaskSource.GetResult(short token)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      ValueTask IAsyncDisposable.DisposeAsync()
      {
        if (this.\u003C\u003E1__state >= -1)
          throw new NotSupportedException();
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask();
        this.\u003C\u003Ew__disposeMode = true;
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6 stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003CGetIndefinitelyRunningRangeAsync\u003Ed__6>(ref stateMachine);
        return new ValueTask((IValueTaskSource) this, this.\u003C\u003Ev__promiseOfValueOrEnd.Version);
      }
    }

    [CompilerGenerated]
    private sealed class \u003CIndefinitelyRunningTask\u003Ed__7 : IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncTaskMethodBuilder \u003C\u003Et__builder;
      public CancellationToken cancellationToken;
      public Program \u003C\u003E4__this;
      private TaskAwaiter \u003C\u003Eu__1;

      public \u003CIndefinitelyRunningTask\u003Ed__7()
      {
        base.\u002Ector();
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          TaskAwaiter awaiter;
          int num2;
          if (num1 == 0)
          {
            awaiter = this.\u003C\u003Eu__1;
            this.\u003C\u003Eu__1 = new TaskAwaiter();
            this.\u003C\u003E1__state = num2 = -1;
          }
          else
            goto label_5;
label_4:
          awaiter.GetResult();
          this.cancellationToken.ThrowIfCancelled();
label_5:
          awaiter = Task.Delay(5000).GetAwaiter();
          if (!awaiter.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 0;
            this.\u003C\u003Eu__1 = awaiter;
            Program.\u003CIndefinitelyRunningTask\u003Ed__7 stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003CIndefinitelyRunningTask\u003Ed__7>(ref awaiter, ref stateMachine);
          }
          else
            goto label_4;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003C\u003Et__builder.SetException(ex);
        }
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }

    [CompilerGenerated]
    private sealed class \u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed : 
      IAsyncEnumerable<int>,
      IAsyncEnumerator<int>,
      IAsyncDisposable,
      IValueTaskSource<bool>,
      IValueTaskSource,
      IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncIteratorMethodBuilder \u003C\u003Et__builder;
      public ManualResetValueTaskSourceCore<bool> \u003C\u003Ev__promiseOfValueOrEnd;
      private int \u003C\u003E2__current;
      private bool \u003C\u003Ew__disposeMode;
      private int \u003C\u003El__initialThreadId;
      private System.Threading.CancellationToken cancellationToken;
      public System.Threading.CancellationToken \u003C\u003E3__cancellationToken;
      private int \u003Cindex\u003E5__1;
      private TaskAwaiter \u003C\u003Eu__1;

      [DebuggerHidden]
      public \u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed(
        int _param1)
      {
        base.\u002Ector();
        this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
        this.\u003C\u003E1__state = _param1;
        this.\u003C\u003El__initialThreadId = Environment.CurrentManagedThreadId;
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          TaskAwaiter awaiter;
          switch (num1)
          {
            case -4:
              this.\u003C\u003E1__state = num2 = -1;
              if (!this.\u003C\u003Ew__disposeMode)
                goto label_8;
              else
                goto label_10;
            case 0:
              awaiter = this.\u003C\u003Eu__1;
              this.\u003C\u003Eu__1 = new TaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              if (!this.\u003C\u003Ew__disposeMode)
              {
                this.\u003C\u003E1__state = num2 = -1;
                this.\u003Cindex\u003E5__1 = 0;
                goto label_8;
              }
              else
                goto label_10;
          }
label_6:
          awaiter.GetResult();
          this.\u003C\u003E2__current = this.\u003Cindex\u003E5__1++;
          this.\u003C\u003E1__state = num2 = -4;
          goto label_11;
label_8:
          awaiter = Task.Delay(5000, this.cancellationToken).GetAwaiter();
          if (!awaiter.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 0;
            this.\u003C\u003Eu__1 = awaiter;
            Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed>(ref awaiter, ref stateMachine);
            return;
          }
          goto label_6;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003C\u003Et__builder.Complete();
          this.\u003C\u003Ev__promiseOfValueOrEnd.SetException(ex);
          return;
        }
label_10:
        this.\u003C\u003E1__state = -2;
        this.\u003C\u003Et__builder.Complete();
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(false);
        return;
label_11:
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(true);
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }

      [DebuggerHidden]
      IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(
        System.Threading.CancellationToken cancellationToken)
      {
        Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed runningRangeAsync20D;
        if (this.\u003C\u003E1__state == -2 && this.\u003C\u003El__initialThreadId == Environment.CurrentManagedThreadId)
        {
          this.\u003C\u003E1__state = -3;
          this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
          this.\u003C\u003Ew__disposeMode = false;
          runningRangeAsync20D = this;
        }
        else
          runningRangeAsync20D = new Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed(-3);
        runningRangeAsync20D.cancellationToken = this.\u003C\u003E3__cancellationToken;
        return (IAsyncEnumerator<int>) runningRangeAsync20D;
      }

      [DebuggerHidden]
      ValueTask<bool> IAsyncEnumerator<int>.MoveNextAsync()
      {
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask<bool>();
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed>(ref stateMachine);
        short version = this.\u003C\u003Ev__promiseOfValueOrEnd.Version;
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded ? new ValueTask<bool>(this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(version)) : new ValueTask<bool>((IValueTaskSource<bool>) this, version);
      }

      int IAsyncEnumerator<int>.Current
      {
        [DebuggerHidden] get
        {
          return this.\u003C\u003E2__current;
        }
      }

      [DebuggerHidden]
      bool IValueTaskSource<bool>.GetResult(short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource<bool>.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      void IValueTaskSource.GetResult(short token)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      ValueTask IAsyncDisposable.DisposeAsync()
      {
        if (this.\u003C\u003E1__state >= -1)
          throw new NotSupportedException();
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask();
        this.\u003C\u003Ew__disposeMode = true;
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003C\u003CCancelledIndefiniteEnumerationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C2_0\u003Ed>(ref stateMachine);
        return new ValueTask((IValueTaskSource) this, this.\u003C\u003Ev__promiseOfValueOrEnd.Version);
      }
    }

    [CompilerGenerated]
    private sealed class \u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed : 
      IAsyncEnumerable<int>,
      IAsyncEnumerator<int>,
      IAsyncDisposable,
      IValueTaskSource<bool>,
      IValueTaskSource,
      IAsyncStateMachine
    {
      public int \u003C\u003E1__state;
      public AsyncIteratorMethodBuilder \u003C\u003Et__builder;
      public ManualResetValueTaskSourceCore<bool> \u003C\u003Ev__promiseOfValueOrEnd;
      private int \u003C\u003E2__current;
      private bool \u003C\u003Ew__disposeMode;
      private int \u003C\u003El__initialThreadId;
      private System.Threading.CancellationToken cancellationToken;
      public System.Threading.CancellationToken \u003C\u003E3__cancellationToken;
      private int \u003Cindex\u003E5__1;
      private TaskAwaiter \u003C\u003Eu__1;

      [DebuggerHidden]
      public \u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed(
        int _param1)
      {
        base.\u002Ector();
        this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
        this.\u003C\u003E1__state = _param1;
        this.\u003C\u003El__initialThreadId = Environment.CurrentManagedThreadId;
      }

      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.\u003C\u003E1__state;
        try
        {
          int num2;
          TaskAwaiter awaiter;
          switch (num1)
          {
            case -4:
              this.\u003C\u003E1__state = num2 = -1;
              if (!this.\u003C\u003Ew__disposeMode)
                goto label_8;
              else
                goto label_10;
            case 0:
              awaiter = this.\u003C\u003Eu__1;
              this.\u003C\u003Eu__1 = new TaskAwaiter();
              this.\u003C\u003E1__state = num2 = -1;
              break;
            default:
              if (!this.\u003C\u003Ew__disposeMode)
              {
                this.\u003C\u003E1__state = num2 = -1;
                this.\u003Cindex\u003E5__1 = 0;
                goto label_8;
              }
              else
                goto label_10;
          }
label_6:
          awaiter.GetResult();
          this.\u003C\u003E2__current = this.\u003Cindex\u003E5__1++;
          this.\u003C\u003E1__state = num2 = -4;
          goto label_11;
label_8:
          awaiter = Task.Delay(5000, this.cancellationToken).GetAwaiter();
          if (!awaiter.IsCompleted)
          {
            this.\u003C\u003E1__state = num2 = 0;
            this.\u003C\u003Eu__1 = awaiter;
            Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed stateMachine = this;
            this.\u003C\u003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed>(ref awaiter, ref stateMachine);
            return;
          }
          goto label_6;
        }
        catch (Exception ex)
        {
          this.\u003C\u003E1__state = -2;
          this.\u003C\u003Et__builder.Complete();
          this.\u003C\u003Ev__promiseOfValueOrEnd.SetException(ex);
          return;
        }
label_10:
        this.\u003C\u003E1__state = -2;
        this.\u003C\u003Et__builder.Complete();
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(false);
        return;
label_11:
        this.\u003C\u003Ev__promiseOfValueOrEnd.SetResult(true);
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }

      [DebuggerHidden]
      IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(
        System.Threading.CancellationToken cancellationToken)
      {
        Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed runningRangeAsync30D;
        if (this.\u003C\u003E1__state == -2 && this.\u003C\u003El__initialThreadId == Environment.CurrentManagedThreadId)
        {
          this.\u003C\u003E1__state = -3;
          this.\u003C\u003Et__builder = AsyncIteratorMethodBuilder.Create();
          this.\u003C\u003Ew__disposeMode = false;
          runningRangeAsync30D = this;
        }
        else
          runningRangeAsync30D = new Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed(-3);
        runningRangeAsync30D.cancellationToken = this.\u003C\u003E3__cancellationToken;
        return (IAsyncEnumerator<int>) runningRangeAsync30D;
      }

      [DebuggerHidden]
      ValueTask<bool> IAsyncEnumerator<int>.MoveNextAsync()
      {
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask<bool>();
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed>(ref stateMachine);
        short version = this.\u003C\u003Ev__promiseOfValueOrEnd.Version;
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded ? new ValueTask<bool>(this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(version)) : new ValueTask<bool>((IValueTaskSource<bool>) this, version);
      }

      int IAsyncEnumerator<int>.Current
      {
        [DebuggerHidden] get
        {
          return this.\u003C\u003E2__current;
        }
      }

      [DebuggerHidden]
      bool IValueTaskSource<bool>.GetResult(short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource<bool>.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      void IValueTaskSource.GetResult(short token)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.GetResult(token);
      }

      [DebuggerHidden]
      ValueTaskSourceStatus IValueTaskSource.GetStatus(
        short token)
      {
        return this.\u003C\u003Ev__promiseOfValueOrEnd.GetStatus(token);
      }

      [DebuggerHidden]
      void IValueTaskSource.OnCompleted(
        Action<object> continuation,
        object state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
      {
        this.\u003C\u003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
      }

      [DebuggerHidden]
      ValueTask IAsyncDisposable.DisposeAsync()
      {
        if (this.\u003C\u003E1__state >= -1)
          throw new NotSupportedException();
        if (this.\u003C\u003E1__state == -2)
          return new ValueTask();
        this.\u003C\u003Ew__disposeMode = true;
        this.\u003C\u003Ev__promiseOfValueOrEnd.Reset();
        Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed stateMachine = this;
        this.\u003C\u003Et__builder.MoveNext<Program.\u003C\u003CNotCancelledIndefiniteEnumerationWithCancellationExample\u003Eg__GetIndefinitelyRunningRangeAsync\u007C3_0\u003Ed>(ref stateMachine);
        return new ValueTask((IValueTaskSource) this, this.\u003C\u003Ev__promiseOfValueOrEnd.Version);
      }
    }
  }
}