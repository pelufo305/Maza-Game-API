using Maze.Domain.Entities;
using static Maze.Domain.Enum.Enumcs;

namespace Maze.Domain.Model
{
    /// <summary>
    /// Represents the player 
    /// which will be responsible
    /// for moving throughout the maze
    /// </summary>
    public abstract class APlayer
    {
        private Cell cell; /// the cell the player is occupying

        /// <summary>
        /// The last direction the player moved.
        /// </summary>
        public PlayerOperation LastDirectionMoved
        {
            get;
            set;
        }





        /// <summary>
        /// Returns the game cell
        /// in which the player exists
        /// </summary>
        public Cell Cell
        {
            get { return cell; }
            set { cell = value; }
        }

    }
}
