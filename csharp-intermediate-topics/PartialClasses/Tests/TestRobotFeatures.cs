using PartialClasses;

namespace Tests;

public class RobotTests
{
    private Robot _testedRobot;

    [SetUp]
    public void Setup()
    {
        _testedRobot = new Robot();
        _testedRobot.Recharge();
    }

    [Test]
    public void WhenRecharge_ThenFullyCharged()
    {
        // Arrange
        var emptyRobot = new Robot();
        var initialCharge = emptyRobot.GetChargeRemaining();
        
        // Act
        emptyRobot.Recharge();

        // Assert
        var newChargeLevel = emptyRobot.GetChargeRemaining();
        Assert.Multiple(() =>
        {
            Assert.That(initialCharge, Is.EqualTo(0), "Initial charge must be 0");
            Assert.That(newChargeLevel, Is.EqualTo(100), "Recharged, charge level must be 100");
        });
    }

    [Test]
    public void GivenEnoughCharge_WhenWalking_ThenCorrectDistanceAndChargeChanges()
    {
        // Arrange
        var initialDistanceCovered = _testedRobot.DistanceCovered;
        var initialChargeLevel = _testedRobot.GetChargeRemaining();

        // Act
        _testedRobot.Walk();
        
        // Assert
        var newDistanceCovered = _testedRobot.DistanceCovered;
        var newChargeLevel = _testedRobot.GetChargeRemaining();

        Assert.Multiple(() =>
        {
            Assert.That(newDistanceCovered - initialDistanceCovered, 
                            Is.EqualTo(Robot.WalkDistance), 
                            "Must have walked walking distance");
            
            Assert.That(initialChargeLevel - newChargeLevel, 
                            Is.EqualTo(Robot.WalkChargeRequired), 
                            "Must have used walking charge level");
        });
    }
    
    [Test]
    public void GivenNotEnoughCharge_WhenWalking_ThenNothingChanges()
    {
        // Arrange
        var initialDistanceCovered = _testedRobot.DistanceCovered;
        var initialChargeLevel = _testedRobot.GetChargeRemaining();

        // Act
        var walkingSteps = 0;
        while (_testedRobot.GetChargeRemaining() >= Robot.WalkChargeRequired)
        {
            _testedRobot.Walk();
            walkingSteps += 1;
        }
        _testedRobot.Walk();
        
        // Assert
        var newDistanceCovered = _testedRobot.DistanceCovered;
        var newChargeLevel = _testedRobot.GetChargeRemaining();

        Assert.Multiple(() =>
        {
            Assert.That(newDistanceCovered - initialDistanceCovered, 
                            Is.EqualTo(Robot.WalkDistance * walkingSteps), 
                            "Must have walked steps' long walking distance");
            
            Assert.That(newChargeLevel, Is.EqualTo(0), 
                            "Must have used up all the charge level");
        });
    }
    
    [Test]
    public void GivenEnoughCharge_WhenJumping_ThenCorrectDistanceAndChargeChanges()
    {
        // Arrange
        var initialDistanceCovered = _testedRobot.DistanceCovered;
        var initialChargeLevel = _testedRobot.GetChargeRemaining();

        // Act
        _testedRobot.Jump();
        
        // Assert
        var newDistanceCovered = _testedRobot.DistanceCovered;
        var newChargeLevel = _testedRobot.GetChargeRemaining();

        Assert.Multiple(() =>
        {
            Assert.That(newDistanceCovered - initialDistanceCovered, 
                            Is.EqualTo(Robot.JumpDistance), 
                            "Must have jumped jumping distance");
            
            Assert.That(initialChargeLevel - newChargeLevel, 
                            Is.EqualTo(Robot.JumpChargeRequired), 
                            "Must have used jumping charge level");
        });
    }
    
    [Test]
    public void GivenNotEnoughCharge_WhenJumping_ThenWalking()
    {
        // Arrange
        var initialDistanceCovered = _testedRobot.DistanceCovered;
        var initialChargeLevel = _testedRobot.GetChargeRemaining();

        // Act
        var jumpsPerformed = 0;
        while (_testedRobot.GetChargeRemaining() >= Robot.JumpChargeRequired)
        {
            _testedRobot.Jump();
            jumpsPerformed += 1;
        }
        _testedRobot.Jump();
        
        // Assert
        var newDistanceCovered = _testedRobot.DistanceCovered;
        var newChargeLevel = _testedRobot.GetChargeRemaining();

        Assert.Multiple(() =>
        {
            Assert.That(newDistanceCovered - initialDistanceCovered, 
                            Is.EqualTo(Robot.JumpDistance * jumpsPerformed + Robot.WalkDistance), 
                            "Must have walked the last jump");
            
            Assert.That(initialChargeLevel - newChargeLevel, 
                            Is.EqualTo(Robot.JumpChargeRequired * jumpsPerformed + Robot.WalkChargeRequired), 
                            "Must have used up the exact charge for the jumps and 1 last walk");
        });
    }
}