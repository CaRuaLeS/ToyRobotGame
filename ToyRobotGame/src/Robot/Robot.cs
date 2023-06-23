using ToyRobotGame.src.Helpers;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;

namespace ToyRobotGame.src.Robot
{
    public class Robot: IRobot, IRobotActions, IGameActions
    {
        public int XYBoardSize = 5;
        public Coordinate Position { get; set; } = null!;
        public Direction Facing { get; set; }

        public List<Wall> walls;
        private  readonly Conditions conditions;

        public Robot()
        {
            walls = new List<Wall>();
            conditions = new Conditions(XYBoardSize);
        }

        public void PlaceRobot(int column, int row, Direction facing)
        {
            Coordinate placeCoordinate = new(column, row);

            if (conditions.IsInsideBoardCoordinate(placeCoordinate) && !conditions.IsOccupiedCoordinate(placeCoordinate, this, walls))
            {
                this.Position = placeCoordinate;
                this.Facing = facing;
            }
            else
            {
                throw new CustomException($"Invalid coordinate. Make sure it is between 1 and {XYBoardSize} and it's not occupied.");
            }
        }
        public void Move() 
        {
            if (this.Position != null && conditions.IsInsideBoardCoordinate(this.Position))
            {
                Coordinate newCoordinate = CalculateNewCoordinatePosition();
                if (!conditions.IsOccupiedCoordinate(newCoordinate, this, walls))
                {
                    this.Position = newCoordinate;                   
                }
                else
                {
                    throw new CustomException("Obstacle ahead. Can't move forwards.");
                }
                    
            }else { throw new CustomException("Invalid action. No robot placed on the board."); }
        }
        public void LookLeft() 
        {
            ChangeFacingDirection(-1);
        }
        public void LookRight()
        {
            ChangeFacingDirection(+1);
        }
       
        public void PlaceWall(int column, int row) 
        {
            Coordinate wallCoordinate = new (column, row);

            if (conditions.IsInsideBoardCoordinate(wallCoordinate))
            {
                Wall newWall = new(wallCoordinate);
                if (!conditions.IsOccupiedCoordinate(wallCoordinate, this, walls))
                {
                    walls.Add(newWall);
                }
                else { throw new CustomException("Occupied coordinate."); }
            }
            else { throw new CustomException($"Invalid coordinate. Make sure it is between 1 and {XYBoardSize}."); }
        }

        private void ChangeFacingDirection(int sideToLook)
        {
            // SideToLook = -1 --> Look left
            // SideToLook = 1 --> Look right

            if (this.Position != null)
            {
                int newValue = ((int)this.Facing + sideToLook) % 4;
                if (newValue < 1) { newValue = 4; }

                this.Facing = (Direction)newValue;
            }
            else { throw new CustomException("Invalid action. No robot placed on the board."); }
        }

        private Coordinate CalculateNewCoordinatePosition()
        {
            Coordinate newPosition = new(this.Position.Column, this.Position.Row);

            switch (this.Facing)
            {
                case Direction.NORTH:
                    newPosition.Row++;
                    break;
                case Direction.SOUTH:
                    newPosition.Row--;
                    break;
                case Direction.EAST:
                    newPosition.Column++;
                    break;
                case Direction.WEST:
                    newPosition.Column--;
                    break;
            }

            if (newPosition.Row < 1)
            {
                newPosition.Row = XYBoardSize;
            }
            else if (newPosition.Row > XYBoardSize)
            {
                newPosition.Row = 1;
            }

            if (newPosition.Column < 1)
            {
                newPosition.Column = XYBoardSize;
            }
            else if (newPosition.Column > XYBoardSize)
            {
                newPosition.Column = 1;
            }

            return newPosition;
        }
    }
}

