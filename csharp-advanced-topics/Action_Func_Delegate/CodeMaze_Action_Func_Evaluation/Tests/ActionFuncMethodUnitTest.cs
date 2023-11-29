namespace Tests;

using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using CodeMaze_Func_Action_Evaluation;
[TestFixture]
public class ProgramTests
{
    [Test]
    public void Given_AddNumberDelegate_When_CallingWith5And7_Then_PrintAdditionResult()
     {
        // Given
        var param1 = 5;
        var param2 = 7;
        var expectedOutput = "Addition = 12";

        // When
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Func_Action_Delegate_Demo.AddNumberDelegate(param1, param2);
            var actualOutput = sw.ToString().Trim();

            // Then
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
            
        }
    }

    [Test]
    public void Given_AddNumberDelegateLambda_When_CallingWith5And7_Then_PrintAdditionResult()
     {
        // Given
        var param1 = 5;
        var param2 = 7;
        var expectedOutput = "AdditionLambda = 12";

        // When
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Func_Action_Delegate_Demo.AddNumberDelegateLambda(param1, param2);
            var actualOutput = sw.ToString().Trim();

            // Then
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
            
        }
    }

    [Test]
    public void Given_MultiplyDelegate_When_CallingWith50And3_Then_ReturnMultiplicationResult()
    {
        // Given
        var param1 = 50;
        var param2 = 3;
        var expectedResult = 150;
         
        // When
        int actualResult = Func_Action_Delegate_Demo.MultiplyDelegate(param1, param2);

        // Then
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Given_MultiplyDelegateLambda_When_CallingWith50And3_Then_ReturnMultiplicationResult()
    {
        // Given
        var param1 = 50;
        var param2 = 3;
        var expectedResult = 150;
         
        // When
        int actualResult = Func_Action_Delegate_Demo.MultiplyDelegateLambda(param1, param2);

        // Then
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}