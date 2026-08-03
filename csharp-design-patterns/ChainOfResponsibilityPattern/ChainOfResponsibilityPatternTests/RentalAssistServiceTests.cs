using ChainOfResponsibilityPattern;
using ChainOfResponsibilityPattern.Solution;

namespace ChainOfResponsibilityPatternTests;

public class RentalAssistServiceTests
{
    [Fact]
    public void GivenNonFacultyUser_WhenRequestsForAFacultyBook_ThenReceivesFacultyOnlyAccessResponse()
    {
        var request = new RentalRequest("UserA", "BookC");

        var result = new RentalAssistService().AssessRentRequest(request);

        Assert.Equal(RentalResponse.FacultyOnlyAccess, result);
    }

    [Fact]
    public void GivenValidRequest_WhenIsCalledForRentalAssessment_ThenReceivesResponseUptoAssessmentSteps()
    {
        var request = new RentalRequest("UserB", "BookA");

        var result = new RentalAssistService().AssessRentRequest(request);

        Assert.Equal(RentalResponse.RentalApproved, result);
    }

    [Fact]
    public void GivenValidRequest_WhenIsCalledForRentalProcessing_ThenReceivesResponseIncludingIssuanceStep()
    {
        var request = new RentalRequest("UserB", "BookA");

        var result = new RentalAssistService().ProcessRentRequest(request);

        Assert.Equal(RentalResponse.RentalIssued, result);
    }
}