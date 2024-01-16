using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Model
{
    public class MazeDefinitionResponse
    {

        public MazeDefinitionResponse()
        {
            this.Blocks = new List<MazeBlockView>();
        }

        public Guid MazeUid { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public List<MazeBlockView> Blocks { get; set; }
    }


    public class MazeDefinitionGameResponse
    {

        public MazeDefinitionGameResponse()
        {
            this.Blocks = new List<MazeBlockView>();
        }

        public Guid MazeUid { get; set; }
        public Guid GameUid { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public List<MazeBlockView> Blocks { get; set; }
    }
}
