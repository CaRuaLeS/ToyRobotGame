using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;

namespace ToyRobotGame.src.Robot
{
    public class Robot: IRobot, IRobotActions, IGameActions
    {
        private int XYBoardSize = 5;
        public Coordinate Position { get; set; }
        public Direction Facing { get; set; }

        public List<Wall> walls;

        //public Robot(Coordinate position, Direction facing)
        //{
        //    this.Position = position;
        //    this.Facing = facing;
        //}

        public void PlaceRobot(int row, int column, Direction facing)
        {
            Coordinate placeCoordinate = new(row, column);

            if (isValidCoordinate(placeCoordinate))
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
            if (this != null)
            {
                if (this.Position != null)
                {
                    if (isValidCoordinate(this.Position))
                    {
                        Coordinate newCoordinate = CalculateNewCoordinatePosition();
                        if (!isOccupiedCoordinate(newCoordinate))
                        {
                        this.Position = newCoordinate;
                            
                        }
                    }
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
            if (this != null)
            {
                Console.WriteLine($"{this.Position.Row},{this.Position.Column},{this.Facing}");
            }
        }
        public void PlaceWall(int row, int column) 
        {
            Coordinate wallCoordinate = new Coordinate(row, column);

            if (isValidCoordinate(wallCoordinate))
            {
                Wall newWall = new(wallCoordinate);
                if (!isOccupiedCoordinate(wallCoordinate))
                {
                    walls.Add(newWall);
                }
            }
        }

        private void ChangeFacingDirection(int sideToLook)
        {
            // SideToLook = -1 --> Look left
            // SideToLook = 1 --> Look right

            if (this != null)
            {
                int newValue = ((int)this.Facing + sideToLook) % 4;
                if (newValue < 1) { newValue = 4; }

                this.Facing = (Direction)newValue;
            }
        }
        private bool isValidCoordinate(Coordinate position)
        {
            if (position.Row >= 1 && position.Row <= XYBoardSize && position.Column >= 1 && position.Column <= XYBoardSize)
            {
                return true;
            }
            return false;
        }
        private bool isOccupiedCoordinate(Coordinate position)
        {

            if (this != null && this.Position.Row == position.Row && this.Position.Column == position.Column
                || walls.Exists(wall => wall.Position.Row == position.Row && wall.Position.Column == position.Column))
            {
                return true;
            }
            return false;

        }
        private Coordinate CalculateNewCoordinatePosition()
        {
            Coordinate newPosition = new(this.Position.Row, this.Position.Column);

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

