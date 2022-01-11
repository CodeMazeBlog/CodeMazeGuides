using Xunit;
using ScenarioWithDelegates;
using static ScenarioWithDelegates.Program;
using System;
using Moq;
using System.Threading.Tasks;

namespace Test
{
    public class ScenarioWithDelegatesTests
    {
        [Fact]
        public void CreateRandomNameGeneratorTask_Task_Invokes_Notify_The_Client_By_Given_CallOnFailure_Delegate_If_Generation_Is_Unsuccessful()
        {
            // Arrange
            bool onFailureDelegateTriggedTargetMethod = false;
            OnFailure onFailureDelegate = (Exception ex) => { onFailureDelegateTriggedTargetMethod = true; };
            bool onSuccessfulDelegateTriggedTargetMethod = false;
            OnSuccessful onSuccessfulDelegate = (string generatedRandomName) => { onSuccessfulDelegateTriggedTargetMethod = true; };

            Mock<IHttpClient> mockHttpClient = new();
            mockHttpClient.Setup(mockClient => mockClient.SendGetRequest<It.IsAnyType>(It.IsAny<string>()))
                .Throws(new Exception("Exception occurred!"));

            // Act
            Task randomNameGenerationTask = Program.CreateRandomNameGeneratorTask(onSuccessfulDelegate, onFailureDelegate, mockHttpClient.Object);
            randomNameGenerationTask.Start();
            randomNameGenerationTask.Wait();

            // Assert
            Assert.True(onFailureDelegateTriggedTargetMethod);
            Assert.False(onSuccessfulDelegateTriggedTargetMethod);
        }

        [Fact]
        public void CreateRandomNameGeneratorTask_Task_Invokes_Notify_The_Client_By_Given_OnSuccessful_Delegate_If_Generation_Is_Successful()
        {
            // Arrange
            bool onFailureDelegateTriggedTargetMethod = false;
            OnFailure onFailureDelegate = (Exception ex) => { onFailureDelegateTriggedTargetMethod = true; };
            bool onSuccessfulDelegateTriggedTargetMethod = false;
            OnSuccessful onSuccessfulDelegate = (string generatedRandomName) => { onSuccessfulDelegateTriggedTargetMethod = true; };

            Mock<IHttpClient> mockHttpClient = new();
            mockHttpClient.Setup(mockClient => mockClient.SendGetRequest<RandomUserResponse>(It.IsAny<string>()))
                .Returns(new RandomUserResponse { Results = new RandomUser[] { new RandomUser { Name = new RandomUserName() } } });

            // Act
            Task randomNameGenerationTask = Program.CreateRandomNameGeneratorTask(onSuccessfulDelegate, onFailureDelegate, mockHttpClient.Object);
            randomNameGenerationTask.Start();
            randomNameGenerationTask.Wait();

            // Assert
            Assert.False(onFailureDelegateTriggedTargetMethod);
            Assert.True(onSuccessfulDelegateTriggedTargetMethod);
        }
    }
}
