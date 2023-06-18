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

        public Robot()
        {
            walls = new List<Wall>();
        }

        public void PlaceRobot(int column, int row, Direction facing)
        {
            Coordinate placeCoordinate = new(column, row);

            if (IsValidCoordinate(placeCoordinate))
            {

                if (this == null)
                {
                    this.Position = new Coordinate(row, column);
                    this.Facing = facing;
                }
                else
                {
                    this.Position = placeCoordinate;
                    this.Facing = facing;
                }

            }
        }
        public void Move() 
        {
            if (this.Position != null && IsValidCoordinate(this.Position))
            {
                Coordinate newCoordinate = CalculateNewCoordinatePosition();
                if (!IsOccupiedCoordinate(newCoordinate))
                {
                this.Position = newCoordinate;
                            
                }
                    
            }
        }
        public void LookLeft() 
        {
            ChangeFacingDirection(-1);
        }
        public void LookRight()
        {
            ChangeFacingDirection(+1);
        }
        public void Report()
        {
            if (this.Position != null)
            {
                Console.WriteLine($"{this.Position.Column},{this.Position.Row},{this.Facing}");
            }
        }
        public void PlaceWall(int column, int row) 
        {
            Coordinate wallCoordinate = new (column, row);

            if (IsValidCoordinate(wallCoordinate))
            {
                Wall newWall = new(wallCoordinate);
                if (!IsOccupiedCoordinate(wallCoordinate))
                {
                    walls.Add(newWall);
                }
            }
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
        }
        private bool IsValidCoordinate(Coordinate position)
        {
            if (position.Row >= 1 && position.Row <= XYBoardSize && position.Column >= 1 && position.Column <= XYBoardSize)
            {
                return true;
            }
            return false;
        }
        private bool IsOccupiedCoordinate(Coordinate position)
        {

            if (this.Position != null && this.Position.Row == position.Row && this.Position.Column == position.Column
                || walls.Exists(wall => wall.Position.Row == position.Row && wall.Position.Column == position.Column))
            {
                return true;
            }
            return false;

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

