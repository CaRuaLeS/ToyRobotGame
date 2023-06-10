using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;
using Xunit;

namespace ToyRobot_Test.ActionsTest
{
    //public class RobotActionTest
    //{
    //    // Test wall with move left (NOT IMPLEMENTED)
    //    [Fact]
    //    public void Move_FacingNorth_ResultPositionToBe21()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(1, 1);
    //        Robot testRobot = new(testCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.Move(testRobot);

    //        // Assert
    //        Assert.NotNull(testRobot);
    //        Assert.Equal(2, testRobot.Position.Row);
    //        Assert.Equal(1, testRobot.Position.Column);

    //    }

    //    [Fact]
    //    public void Move_FacingNorthPassTheEdge_ResultPositionToBe11()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(4, 1);
    //        Robot testRobot = new(testCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.Move(testRobot);

    //        // Assert
    //        Assert.Equal(1, testRobot.Position.Row);
    //        Assert.Equal(1, testRobot.Position.Column);

    //    }

    //    [Fact]
    //    public void InvalidMove_TheresNoValidPosition_InRobotCoordinates()
    //    {
    //        // Arrange
    //        Coordinate testErrorCoordinate = new(0, 0);
    //        Robot testRobot = new(testErrorCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.Move(testRobot);

    //        // Assert
    //        Assert.Equal(0, testRobot.Position.Row);
    //        Assert.Equal(0, testRobot.Position.Column);

    //    }

    //    [Fact]
    //    public void LookLeft_FinishLookingWest()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(1, 1);
    //        Robot testRobot = new(testCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.LookLeft(testRobot);

    //        // Assert
    //        Assert.Equal(Direction.WEST, testRobot.Facing);

    //    }

    //    [Fact]
    //    public void LookRight_FinishLookingEast()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(1, 1);
    //        Robot testRobot = new(testCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.LookRight(testRobot);

    //        // Assert
    //        Assert.Equal(Direction.EAST, testRobot.Facing);

    //    }
    //    [Fact]
    //    public void LookRight_FinishLookingNorth_PassFrom4To1()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(1, 1);
    //        Robot testRobot = new(testCoordinate, Direction.WEST);
    //        var action = new RobotAction();

    //        // Act
    //        action.LookRight(testRobot);

    //        // Assert
    //        Assert.Equal(Direction.NORTH, testRobot.Facing);

    //    }

    //    [Fact]
    //    public void LookingMultipleTimes_FinishLookingSouth()
    //    {
    //        // Arrange
    //        Coordinate testCoordinate = new(1, 1);
    //        Robot testRobot = new(testCoordinate, Direction.NORTH);
    //        var action = new RobotAction();

    //        // Act
    //        action.LookLeft(testRobot);
    //        action.LookRight(testRobot);
    //        action.LookRight(testRobot);
    //        action.LookLeft(testRobot);
    //        action.LookLeft(testRobot);
    //        action.LookLeft(testRobot);
    //        action.LookLeft(testRobot);
    //        action.LookRight(testRobot);

    //        // Assert
    //        Assert.Equal(Direction.SOUTH, testRobot.Facing);

    //    }
    //}
}
