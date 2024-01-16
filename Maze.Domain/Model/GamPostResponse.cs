using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Model
{
    public class GamPostResponse
    {
        public Guid MazeUid { get; set; }
        public Guid GameUid { get; set; }
        public bool Completed { get; set; }

        public int CurrentPositionX { get; set; }

        public int CurrentPositionY { get; set; }
    }
}
