using Maze.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Maze.Domain.Enum.Enumcs;

namespace Maze.API.Controllers
{
    
     [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {


        private readonly IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("{mazeUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> StartGame( string mazeUid, [FromBody] GameRequest request)
        {
            var response = await _mediator.Send(new GamePostRequest { MazeUid = System.Guid.Parse(mazeUid),Operation = Enum.Parse<PlayerOperation>(request.Operation) });

            if (response != null && response.Succeeded)
            {
                return Ok(response.Result);
            }
            if (!response.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, (response.ErrorResult));
            }

            return StatusCode(StatusCodes.Status400BadRequest, response != null ? response.ErrorResult : "Error while trying to start the game");
        }


        [HttpPost("{mazeUid}/{gameUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> OperationPlayer(string mazeUid, string gameUid, [FromBody] GameStart request)
        {
            var response = await _mediator.Send(new GameStartRequest { MazeUid = System.Guid.Parse(mazeUid), Operation = Enum.Parse<PlayerOperation>(request.Operation), GameUid = System.Guid.Parse(gameUid) });

            if (response != null && response.Succeeded)
            {
                return Ok(response.Result);
            }
            if (!response.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, (response.ErrorResult));
            }

            return StatusCode(StatusCodes.Status400BadRequest, response != null ? response.ErrorResult : "Error while trying to perform a player operation");
        }


        [HttpGet("{mazeUid}/{gameUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetGame(string mazeUid, string gameUid)
        {
            var response = await _mediator.Send(new MazeDefinitionGameRequest { MazeUid = System.Guid.Parse(mazeUid), GameUid = System.Guid.Parse(mazeUid) });

            if (response != null && response.Succeeded)
            {
                return Ok(response.Result);
            }
            if (!response.Succeeded)
            {
                return StatusCode(StatusCodes.Status404NotFound, (response.ErrorResult));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response != null ? response.ErrorResult : "Error when consulting the maze");
        }



        [HttpGet("{mazeUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetMaze(string mazeUid)
        {
            var response = await _mediator.Send(new MazeDefinitionRequest { MazeUid = System.Guid.Parse(mazeUid) });

            if (response != null && response.Succeeded)
            {
                return Ok(response.Result);
            }
            if (!response.Succeeded)
            {
                return StatusCode(StatusCodes.Status404NotFound, (response.ErrorResult));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response != null ? response.ErrorResult : "Error when consulting the maze");
        }





    }

}
