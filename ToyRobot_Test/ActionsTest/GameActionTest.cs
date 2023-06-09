using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;
using Xunit;
using Xunit.Abstractions;

namespace ToyRobot_Test.ActionsTest
{
    public class GameActionTest
    {

        [Fact]
        public void PlaceRobot_IfNoRobotIsInTheField()
        {
            // Arrange
            
            GameAction testGame = new GameAction();
            int testRow = 2;
            int testColumn = 3;
            var testDirection = Direction.NORTH;

            // Act
            testGame.PlaceRobot(testRow, testColumn, testDirection);

            // Assert
            Assert.Equal(testRow, testGame.robotInstance.Position.Row);
        }

        [Fact]
        public void PlaceRobot_IfPlaceChangesRobotPosition()
        {
            // Arrange
            GameAction testGame = new GameAction();
            Coordinate defaultTestCoordinate = new(1, 1);
            var defaultTestDirection = Direction.NORTH;
            testGame.robotInstance = new Robot(defaultTestCoordinate, defaultTestDirection);

            // Assert --> check first default position
            Assert.Equal(defaultTestCoordinate.Row, testGame.robotInstance.Position.Row);
            Assert.Equal(defaultTestCoordinate.Column, testGame.robotInstance.Position.Column);
            Assert.Equal(defaultTestDirection, testGame.robotInstance.Facing);

            // Act
            int testRow = 2;
            int testColumn = 3;
            testGame.PlaceRobot(testRow, testColumn, defaultTestDirection);

            // Assert
            Assert.Equal(testRow, testGame.robotInstance.Position.Row);
            Assert.Equal(testColumn, testGame.robotInstance.Position.Column);
            Assert.Equal(defaultTestDirection, testGame.robotInstance.Facing);
        }

        [Fact]
        public void PlaceRobot_NoRobotInstantiatedAndChangeItsPosition()
        {
            // Arrange
            GameAction testGame = new GameAction();
            int testRow = 2;
            int testColumn = 3;
            var testDirection = Direction.NORTH;
            var updatedTestDirection = Direction.SOUTH;
            

            // Act
            testGame.PlaceRobot(testRow, testColumn, testDirection);
            Assert.Equal(2, testGame.robotInstance.Position.Row);
            Assert.Equal(3, testGame.robotInstance.Position.Column);
            Assert.Equal(testDirection, testGame.robotInstance.Facing);

            testGame.PlaceRobot(4, 4, updatedTestDirection);

            // Assert
            Assert.Equal(4, testGame.robotInstance.Position.Row);
            Assert.Equal(4, testGame.robotInstance.Position.Column);
            Assert.Equal(updatedTestDirection, testGame.robotInstance.Facing);
        }

        [Fact]
        public void Report_RobotAlreadyPlaced()
        {
            // Arrange

            // StringWriter stores the data
            var consoleOut = new StringWriter();
            // Stores the data in StringWriter()
            Console.SetOut(consoleOut);
            GameAction testGame = new GameAction();

            // Act
            testGame.PlaceRobot(2, 3, Direction.WEST);
            testGame.Report();

            // Assert

            // Enviroment.NewLine sets the output that comes from store data
            string stringResult = "2,3,WEST" + Environment.NewLine;
            var actualOutput = consoleOut.ToString();
            Assert.Equal(stringResult, actualOutput);
        }

        [Fact]
        public void Report_RobotNotPlaced_NoReportResponse()
        {
            // Arrange

            // StringWriter stores the data
            var consoleOut = new StringWriter();
            // Stores the data in StringWriter()
            Console.SetOut(consoleOut);
            GameAction testGame = new GameAction();

            // Act
            testGame.Report();

            // Assert

            // Enviroment.NewLine sets the output that comes from store data
            Assert.Null(testGame.robotInstance);
        }


    }
}
