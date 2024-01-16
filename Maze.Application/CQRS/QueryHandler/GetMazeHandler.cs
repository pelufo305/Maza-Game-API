using Maze.Application.Singleton;
using Maze.Domain.Model;
using Maze.Domain.Repository;
using Maze.Domain.ViewModels.Response;
using MediatR;
using System.Numerics;

namespace Maze.Application.CQRS.QueryHandler
{
    public class GetMazeHandler : IRequestHandler<MazeDefinitionRequest, ResponseBindingModel<MazeDefinitionResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly ISingletonGame _singletonGame;

        public GetMazeHandler(IGameRepository gameRepository, ISingletonGame singletonGame) {

            _gameRepository = gameRepository;
            _singletonGame = singletonGame;

        }
        public async Task<ResponseBindingModel<MazeDefinitionResponse>> Handle(MazeDefinitionRequest request, CancellationToken cancellationToken)
        {
            ResponseBindingModel<MazeDefinitionResponse> result = new ResponseBindingModel<MazeDefinitionResponse>();
            MazeDefinitionResponse mazeDefinitionResponse = new MazeDefinitionResponse();
            GameTransfer gameTransfer = new GameTransfer();
            List<MazeBlockView> lstMazeBlockView = new List<MazeBlockView>();

            try
            {
                var mazeobj = await _gameRepository.GetMaze(request.MazeUid);
                var game = _singletonGame.GetGameList().Where(x => x.MazeUid == request.MazeUid ).FirstOrDefault();
                
                mazeDefinitionResponse.MazeUid = mazeobj.MazeUid;
                mazeDefinitionResponse.Width = mazeobj.Width;
                mazeDefinitionResponse.Height = mazeobj.Height;

                if (game.moveHistory != null)
                {
                    foreach (var move in game.moveHistory)
                    {
                        var movblock = new MazeBlockView { CoordX = move.Row, CoordY = move.Col, EastBlocked = move.eastWall, WestBlocked = move.westWall, NorthBlocked = move.northWall, SouthBlocked = move.southWall };
                        lstMazeBlockView.Add(movblock);
                    }

                }
                mazeDefinitionResponse.Blocks = lstMazeBlockView;
                result.Result = mazeDefinitionResponse;
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
