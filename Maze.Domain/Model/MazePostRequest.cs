using Maze.Domain.ViewModels.Response;
using MediatR;

namespace Maze.Domain.Model
{
    public  class MazePostRequest : IRequest<ResponseBindingModel<MazePostResponse>>
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
