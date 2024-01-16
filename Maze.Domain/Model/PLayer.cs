using Maze.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Maze.Domain.Enum.Enumcs;

namespace Maze.Domain.Model
{
    public class Player : APlayer
    {
        private int numberOfShells = 3;
        private PlayerOperation shotDirection;

        /// <summary>
        /// Creates an player object
        /// which will have a certain
        /// cell within a grid.
        /// </summary>
        /// <param name="position"></param>
        public Player(Cell position)
        {
            shotDirection = PlayerOperation.None;
            this.Cell = position;
        }

        /// <summary>
        /// The number of shells the Player 
        /// remaining.
        /// </summary>
        public int NumberOfShells
        {
            get { return numberOfShells; }
            set { numberOfShells = value; }
        }

        /// <summary>
        /// The direction in which the cannon
        /// is aimed.
        /// </summary>
        public PlayerOperation ShotDirection
        {
            get { return shotDirection; }
            set { shotDirection = value; }
        }
    }
}
