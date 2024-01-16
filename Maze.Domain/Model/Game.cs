using Maze.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Model
{
    public class GameTransfer
    {
        public Guid MazeUid { get; set; }
        public Guid GameUid { get; set; }
        public Cell[,] maze { get; set; }

        public Player player { get; set; }
        public List<Cell> moveHistory { get; set; }

    }
}
