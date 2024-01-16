using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Entities
{
    /// <summary>
    /// Represents a cell in a maze
    /// with four walls which will 
    /// either be passable or impassable
    /// </summary>
    public class Cell
    {
        private bool westWallBlocked = true, eastWallBlocked = true, northWallBlocked = true, southWallBlocked = true;
        private int cellRow, cellCol;
        private bool cellVisisted;


        /// <summary>
        /// Copy contructure.
        /// </summary>
        /// <param name="cell">The cell to create a copy of.</param>
        public Cell(Cell cell)
        {
            if (cell != null)
            {
                this.westWallBlocked = cell.westWall;
                this.eastWall = cell.eastWall;
                this.northWall = cell.northWall;
                this.Row = cell.Row;
                this.Col = cell.Col;
                this.southWall = cell.southWall;
            }

        }

        /// <summary>
        /// Creates a cell with the 
        /// specified row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        /// <summary>
        /// The column of the cell.
        /// </summary>
        public int Col
        {
            get { return cellCol; }
            set { cellCol = value; }
        }

        /// <summary>
        /// Returns the row of the cell.
        /// </summary>
        public int Row
        {
            get { return cellRow; }
            set { cellRow = value; }
        }

        /// <summary>
        /// Whether the south of the cell
        /// is passable or not.
        /// </summary>
        public bool southWall
        {
            get { return southWallBlocked; }
            set { southWallBlocked = value; }
        }

        /// <summary>
        /// Whether the north of the cell
        /// is passable or not.
        /// </summary>
        public bool northWall
        {
            get { return northWallBlocked; }
            set { northWallBlocked = value; }
        }

        /// <summary>
        /// Whether the east of the cell
        /// is passable or not.
        /// </summary>
        public bool eastWall
        {
            get { return eastWallBlocked; }
            set { eastWallBlocked = value; }
        }

        /// <summary>
        /// Whether the west of the cell
        /// is passable or not.
        /// </summary>
        public bool westWall
        {
            get { return westWallBlocked; }
            set { westWallBlocked = value; }
        }


        /// <summary>
        /// Indicates whether it has been visited
        /// </summary>
        public bool Visited
        {
            get { return cellVisisted; }
            set { cellVisisted = value; }
        }

    }
}
