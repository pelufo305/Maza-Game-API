using Maze.Domain.ViewModels.Response;
using MediatR;
using static Maze.Domain.Enum.Enumcs;


namespace Maze.Domain.Model
{



    public class GamePostRequest : IRequest<ResponseBindingModel<GamPostResponse>>
    {
        public Guid MazeUid { get; set; }
        public PlayerOperation Operation { get; set; }

       
    }

    public class GameRequest
    {
        public string Operation { get; set; }

    }

}
