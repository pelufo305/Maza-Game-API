using Maze.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Maze.Domain.Enum;
using static Maze.Domain.Enum.Enumcs;
using Maze.Domain.Model;

namespace Maze.Application.Components
{

    public class StartGame
    {
        private Cell[,] maze;
        private List<Cell> moveHistory;
        private int rows;
        private int cols;
        private Player player;


        public StartGame(Cell[,] _maze, List<Cell> _moveHistory, int _rows, int _cols , Player _player)
        {
            maze = _maze;
            moveHistory = _moveHistory;
            rows = _rows; 
            cols = _cols;
            player = _player;
        }


        /// <summary>
        /// Attempt to move the player in the supplied
        /// direction.
        /// </summary>
        /// <param name="direction">The direction to move.</param>
        /// <returns>Whether the player has moved</returns>
        public bool MovePlayer(PlayerOperation direction)
        {
            bool moved;

            if (moved = IsFreePosition(player.Cell.Row, player.Cell.Col, direction))
            {

                switch (direction)
                {
                    case PlayerOperation.GoNorth:
                        player.Cell = maze[player.Cell.Row - 1, player.Cell.Col];
                        break;
                    case PlayerOperation.GoSouth:
                        player.Cell = maze[player.Cell.Row + 1, player.Cell.Col];
                        break;
                    case PlayerOperation.GoWest:
                        player.Cell = maze[player.Cell.Row, player.Cell.Col - 1];
                        break;
                    case PlayerOperation.GoEast:
                        player.Cell = maze[player.Cell.Row, player.Cell.Col + 1];
                        break;
                    default:
                        break;
                }

                player.LastDirectionMoved = direction;

                if (moveHistory.Contains(player.Cell))
                {
                    int firstTempPosition = moveHistory.IndexOf(moveHistory.First(number => number == player.Cell));
                    int lastPosition = moveHistory.Count - moveHistory.IndexOf(moveHistory.Last(number => number == player.Cell));
                  moveHistory.RemoveRange(firstTempPosition, lastPosition);
                  moveHistory.Add(player.Cell);
                }


                else
                  moveHistory.Add(player.Cell);

            }

            return moved;
        }

        /// <summary>
        /// Checks to see if the player can move to
        /// the given row or column by checking if 
        /// it is a valid cell and if the wall configuration
        /// will allow the player to travel there.
        /// </summary>
        /// <param name="row">The destination row.</param>
        /// <param name="col">The destination column.</param>
        /// <param name="direction">The direction of the destination from source.</param>
        /// <returns></returns>
        private bool IsFreePosition(int row, int col, PlayerOperation direction)
        {
            switch (direction)
            {
                case PlayerOperation.GoNorth:
                    return (row > 0 && !maze[row - 1, col].southWall);
                case PlayerOperation.GoSouth:
                    return (row < rows - 1 && !maze[row + 1, col].northWall);
                case PlayerOperation.GoEast:
                    return (col < cols - 1 && !maze[row, col + 1].westWall);
                case PlayerOperation.GoWest:
                    return (col > 0 && !maze[row, col - 1].eastWall);
                default:
                    return false;
            }
        }


        /// <summary>
        /// Returns the player.
        /// </summary>
        public Player Actor
        {
            get { return player; }
        }



    }
}
