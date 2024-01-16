using Maze.Domain.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Maze.Domain.Enum.Enumcs;

namespace Maze.Domain.Model
{
    public  class GameStartRequest: IRequest<ResponseBindingModel<GameStartResponse>>
    {
        public Guid MazeUid { get; set; }
        public Guid GameUid { get; set; }
        public PlayerOperation Operation { get; set; }

      
    }

    public class GameStart
    {
        public string Operation { get; set; }


    }
}
