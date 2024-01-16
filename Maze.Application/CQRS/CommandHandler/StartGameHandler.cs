using Maze.Application.Components;
using Maze.Application.Singleton;
using Maze.Domain.Entities;
using Maze.Domain.Model;
using Maze.Domain.Repository;
using Maze.Domain.ViewModels.Response;
using MediatR;

namespace Maze.Application.CQRS.CommandHandler
{
    public class StartGameHandler : IRequestHandler<GamePostRequest, ResponseBindingModel<GamPostResponse>>
    {

        private readonly IGameRepository _gameRepository;
        private readonly ISingletonGame _singletonGame;
        public StartGameHandler(IGameRepository gameRepository, ISingletonGame singletonGame) {

            _gameRepository = gameRepository;
            _singletonGame = singletonGame;
        }

        public async Task<ResponseBindingModel<GamPostResponse>> Handle(GamePostRequest request, CancellationToken cancellationToken)
        {

            ResponseBindingModel<GamPostResponse> result = new ResponseBindingModel<GamPostResponse>();
            GameTransfer gameTransfer = new GameTransfer();
            GamPostResponse gamPostResponse = new GamPostResponse();

            try
            {
                var mazeobj = await _gameRepository.GetMaze(request.MazeUid);

                InitialGame initialGame = new InitialGame(mazeobj.Width, mazeobj.Height);
                
                gameTransfer.MazeUid = request.MazeUid;
                gameTransfer.GameUid = Guid.NewGuid();
                var initializeMaze = initialGame.InitializeMaze();
                var initializeGame = initialGame.InitializeGame();
                gameTransfer.maze = initializeMaze;
                gameTransfer.moveHistory = new List<Cell> { initializeGame };
                gameTransfer.player = initialGame.Actor;
                _singletonGame.Add(gameTransfer);


                gamPostResponse.GameUid = gameTransfer.GameUid;
                gamPostResponse.MazeUid = gameTransfer.MazeUid;
                gamPostResponse.CurrentPositionX = initializeGame.Row;
                gamPostResponse.CurrentPositionY = initializeGame.Col;
                gamPostResponse.Completed = false;

                result.Result = gamPostResponse;
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
