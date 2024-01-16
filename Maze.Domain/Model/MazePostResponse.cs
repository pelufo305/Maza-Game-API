using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Model
{
    public class MazePostResponse
    {
        public Guid MazeUid { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
