using Maze.Domain.Entities;
using Maze.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Application.Components
{
    public  class InitialGame
    {
        private int rows;
        private int cols;
        private Random random;
        private Cell[,] maze;
        private MazeGenerator mazeGenerator;
        private Cell goal;
        private Player player;
      


        /// <summary>
        /// Creates a maze with the specified dimensions
        /// </summary>
        /// <param name="rows">The number of rows of the maze.</param>
        /// <param name="cols"></param>
        public InitialGame(int rows, int cols)
        {
            random = new Random();
            mazeGenerator = new MazeGenerator(rows, cols);

            this.rows = rows;
            this.cols = cols;
        }


        /// <summary>
        /// Creates the maze for the game.
        /// </summary>
        public Cell[,] InitializeMaze()
        {
            mazeGenerator = new MazeGenerator(rows, cols);
            maze = mazeGenerator.GenerateMaze();
            return maze;
        }

        /// <summary>
        /// Start the maze for the game.
        /// </summary>
        public Cell InitializeGame()
        {
            var initial = InitializePlayer();
            SetEndPosition();
            return initial; 
           
        }


        /// <summary>
        /// Sets the end position of the maze. Will continually
        /// find a random cell until the end position is not equal
        /// with the start position.
        /// </summary>
        private void SetEndPosition()
        {
            do
                goal = maze[random.Next(rows), random.Next(cols)];
            while (goal == player.Cell);
        }

        /// <summary>
        /// Set the player
        /// </summary>
        private Cell InitializePlayer()
        {
            player = new Player(maze[random.Next(0, cols - 1), random.Next(0, rows - 1)]);
            return player.Cell;
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
