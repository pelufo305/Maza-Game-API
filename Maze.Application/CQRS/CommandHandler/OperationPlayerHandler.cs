using Maze.Application.Components;
using Maze.Application.Singleton;
using Maze.Domain.Entities;
using Maze.Domain.Model;
using Maze.Domain.Repository;
using Maze.Domain.ViewModels.Response;
using MediatR;
using System.Numerics;
using static Maze.Domain.Enum.Enumcs;

namespace Maze.Application.CQRS.CommandHandler
{
    public class OperationPlayerHandler : IRequestHandler<GameStartRequest, ResponseBindingModel<GameStartResponse>>
    {

        private readonly IGameRepository _gameRepository;
        private readonly ISingletonGame _singletonGame;
        public OperationPlayerHandler(IGameRepository gameRepository, ISingletonGame singletonGame) {

            _gameRepository = gameRepository;
            _singletonGame = singletonGame;
        }
        public async Task<ResponseBindingModel<GameStartResponse>> Handle(GameStartRequest request, CancellationToken cancellationToken)
        {

            ResponseBindingModel<GameStartResponse> result = new ResponseBindingModel<GameStartResponse>();
            GameStartResponse gameStartResponse = new GameStartResponse();
            GameTransfer  gameTransfer = new GameTransfer();

            try
            {
                var mazeobj = await _gameRepository.GetMaze(request.MazeUid);
                var game =  _singletonGame.GetGameList().Where( x => x.MazeUid == request.MazeUid &&  x.GameUid == request.GameUid).FirstOrDefault();
                StartGame startGame = new StartGame (game.maze,game.moveHistory, mazeobj.Width,mazeobj.Height,game.player);

                if (request.Operation == PlayerOperation.Start)
                {
                    _singletonGame.Remove(game);
                    gameTransfer.MazeUid = gameTransfer.MazeUid;
                    gameTransfer.GameUid = gameTransfer.GameUid;
                    gameTransfer.maze = gameTransfer.maze;
                    gameTransfer.player = gameTransfer.player;
                    gameTransfer.moveHistory = new List<Cell>();
                    _singletonGame.Add(gameTransfer);

                    gameStartResponse.Game = new GamPostResponse { Completed = false, GameUid = request.GameUid, MazeUid = request.MazeUid };
                    gameStartResponse.MazeBlockView = null;
                    result.Result = gameStartResponse;
                    result.Succeeded = true;


                } else
                {
                    var mov = startGame.MovePlayer(request.Operation);
                    if (!mov)
                    {
                        result.Succeeded = false;
                        result.ErrorResult = new ErrorMessageBindingModel() { mensaje = "Cannot execute the movement" };
                    }
                    else
                    {
                        _singletonGame.Remove(game);
                        var player = startGame.Actor;
                        gameTransfer.MazeUid = request.MazeUid;
                        gameTransfer.GameUid = request.GameUid;
                        gameTransfer.maze = game.maze;
                        gameTransfer.player = player;
                        gameTransfer.moveHistory = game.moveHistory;
                        gameTransfer.moveHistory.Add(player.Cell);
                        _singletonGame.Add(gameTransfer);

                        gameStartResponse.Game = new GamPostResponse { Completed = false, GameUid = request.GameUid, MazeUid = request.MazeUid, CurrentPositionX = player.Cell.Row, CurrentPositionY = player.Cell.Col };
                        gameStartResponse.MazeBlockView = new MazeBlockView { CoordX = player.Cell.Row, CoordY = player.Cell.Col, EastBlocked = player.Cell.eastWall, WestBlocked = player.Cell.westWall, NorthBlocked = player.Cell.northWall, SouthBlocked = player.Cell.southWall };

                        result.Result = gameStartResponse;
                        result.Succeeded = true;
                    }

                } 

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
