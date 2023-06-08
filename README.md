# ToyRobotGame_Backend_CarlosRuiz

## Toy Robot Game - Backend (C#)

This repository contains the backend implementation of a simple Toy Robot game simulation. The purpose of this project is to assess a candidate's coding abilities and their understanding of software engineering principles and best practices.

## Requirements

Before proceeding, please read the following requirements carefully:

- Aim to deliver production-ready code. Structure your repository as you would for a real project.
- Use Git to track your changes. Once you've completed the implementation, upload your code to GitHub and share the repository URL with us. Ensure that the complete Git commit history is present.
- Implement the solution in C# and demonstrate your understanding of software engineering principles and best practices.
- Include unit tests using any testing library of your choice.
- You have the flexibility to choose how the application handles user inputs: either from a file or from standard input.
- Provide test data to exercise the application.

## Getting Started

To run the Toy Robot game simulation, follow the instructions below:

1. Clone this repository to your local machine.
2. Set up your development environment with the required dependencies.
3. Build and run the application.
4. Choose the input method for the game (file or standard input).
5. Interact with the game by entering commands.
6. View the game's output, including the current location and facing direction of the robot.

## Game Commands

The game responds to the following user commands:

### `PLACE_ROBOT ROW,COL,FACING`

This command places a robot at the specified coordinate with an initial facing direction.

- If there are no robots on the board, the `PLACE_ROBOT` command places one at the specified coordinate.
- If there is already a robot on the board, a new `PLACE_ROBOT` command moves the existing robot to the new location.
- The game ignores the command if the coordinate or facing value is invalid.

Accepted facing values are: `NORTH`, `SOUTH`, `EAST`, `WEST`

**Example Usage:**
```json
PLACE_ROBOT 2,3,NORTH // This places a robot at row 2, column 3, facing North.
PLACE_ROBOT 2,3,CENTER // This command is ignored because the facing direction is invalid.
PLACE_ROBOT 2,6,EAST // This command is ignored because the column coordinate is invalid.
```


### `PLACE_WALL ROW,COL`

This command places a wall at the specified coordinate.

- If the target location is empty, a wall is added to it.
- The user can add as many walls as they like until the board is filled.
- If the target location is occupied by the robot or another wall, the command is ignored.
- Invalid coordinates are ignored.

**Example Usage:**
```json
PLACE_WALL 2,3 // This places a wall at row 2, column 3.
```

### `REPORT`

This command prints out the current location and facing direction of the robot.

- If there are no robots on the board, this command is ignored.

**Example Usage:**
```json
PLACE_ROBOT 2,3,WEST
REPORT // App prints: 2,3,WEST
```

### `MOVE`

This command moves the robot one space forward in the direction it is currently facing.

- If there are no robots on the board, this command is ignored.
- If there is a wall in front of the robot, this command is ignored.
- If the robot has reached the edge of the board, a `MOVE` command towards the edge warps the robot to the opposite side of the board.

**Example Usage:**
```json
PLACE_ROBOT 1,1,NORTH
MOVE
REPORT // App prints: 1,2,NORTH

PLACE_ROBOT 1,1,SOUTH
MOVE
REPORT // App prints: 1,5,SOUTH
```

### `LEFT` / `RIGHT`

These commands turn the robot 90 degrees to its left or right.

- If there are no robots on the board, these commands are ignored.

**Example Usage:**
```json
PLACE_ROBOT 1,1,NORTH
LEFT
REPORT // App prints: 1,1,WEST

RIGHT
REPORT // App prints: 1,1,NORTH
```
