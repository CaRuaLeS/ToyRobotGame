using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Obstacles;

namespace ToyRobot_Test.Obstacles
{
    public class WallTest
    {
        [Fact]
        public void Wall_CreateWithCoordinates()
        {
            // Arrange
            Coordinate testPosition = new (1, 3);

            // Act
            Wall testWall = new (testPosition);

            // Assert
            Assert.Equal(testPosition, testWall.Position);


        }
    }
}
