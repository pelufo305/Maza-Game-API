using Maze.Application.Components;

using Maze.Domain.Entities;
using Maze.Domain.Model;
using Maze.Domain.Repository;
using Maze.Domain.ViewModels.Response;
using MediatR;


namespace Maze.Application.CQRS.CommandHandler
{
    public class CreateNewMazeHandler : IRequestHandler<MazePostRequest, ResponseBindingModel<MazePostResponse>>
    {
        private readonly IGameRepository _gameRepository;
        

        public CreateNewMazeHandler(IGameRepository gameRepository) { 
            _gameRepository = gameRepository;
        }
        
        public async  Task<ResponseBindingModel<MazePostResponse>> Handle(MazePostRequest request, CancellationToken cancellationToken)
        {

            ResponseBindingModel<MazePostResponse> result = new ResponseBindingModel<MazePostResponse>();

            try
            {
                MazeBase mazeBase = new MazeBase();
                mazeBase.MazeUid = Guid.NewGuid();
                mazeBase.Width = request.Width;
                mazeBase.Height = request.Height;

                var resp =  await _gameRepository.addMaze(mazeBase);

                result.Result = new MazePostResponse();
                result.Result.Height = resp.Height;
                result.Result.Width = resp.Width;
                result.Result.MazeUid = resp.MazeUid;
                result.Succeeded = true;


            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.ErrorResult = new ErrorMessageBindingModel() { mensaje = ex.ToString() };
            }

            return result;
          
        }
    }
}
