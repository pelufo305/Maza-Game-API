using Maze.Application.Singleton;
using Maze.Domain.Model;
using Maze.Domain.Repository;
using Maze.Domain.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Application.CQRS.QueryHandler
{
    public class GetGameHandler : IRequestHandler<MazeDefinitionGameRequest, ResponseBindingModel<MazeDefinitionGameResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly ISingletonGame _singletonGame;

        public GetGameHandler(IGameRepository gameRepository, ISingletonGame singletonGame)
        {

            _gameRepository = gameRepository;
            _singletonGame = singletonGame;

        }
        public async Task<ResponseBindingModel<MazeDefinitionGameResponse>> Handle(MazeDefinitionGameRequest request, CancellationToken cancellationToken)
        {
            ResponseBindingModel<MazeDefinitionGameResponse> result = new ResponseBindingModel<MazeDefinitionGameResponse>();
            MazeDefinitionGameResponse mazeDefinitionGameResponse = new MazeDefinitionGameResponse();
            GameTransfer gameTransfer = new GameTransfer();
            List<MazeBlockView> lstMazeBlockView = new List<MazeBlockView>();

            try
            {
                var mazeobj = await _gameRepository.GetMaze(request.MazeUid);
                var game = _singletonGame.GetGameList().Where(x => x.MazeUid == request.MazeUid).FirstOrDefault();

                mazeDefinitionGameResponse.MazeUid = mazeobj.MazeUid;
                mazeDefinitionGameResponse.GameUid = request.GameUid;
                mazeDefinitionGameResponse.Width = mazeobj.Width;
                mazeDefinitionGameResponse.Height = mazeobj.Height;

                if (game.moveHistory != null)
                {
                    foreach (var move in game.moveHistory)
                    {
                        var movblock = new MazeBlockView { CoordX = move.Row, CoordY = move.Col, EastBlocked = move.eastWall, WestBlocked = move.westWall, NorthBlocked = move.northWall, SouthBlocked = move.southWall };
                        lstMazeBlockView.Add(movblock);
                    }

                }
                mazeDefinitionGameResponse.Blocks = lstMazeBlockView;
                result.Result = mazeDefinitionGameResponse;
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
