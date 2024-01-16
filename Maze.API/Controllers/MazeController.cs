using Maze.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maze.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MazeController : Controller
    {


        private readonly IMediator _mediator;
        public MazeController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateNewMaze(MazePostRequest request)
        {
            var response = await _mediator.Send(request);

            if (response != null && response.Succeeded)
            {
                return Ok(response.Result);
            }
            if (!response.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, (response.ErrorResult));
            }

            return StatusCode(StatusCodes.Status400BadRequest, response != null ? response.ErrorResult : "Error while trying to generate the maze");
        }




    }
}
