using Maze.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Repository
{
    public interface IGameRepository
    {
        Task<MazeBase> addMaze(MazeBase maze);
        Task<Game> addGame(Game game);
        Task<Game> UpdatemoveHistory(Guid mazeUid, List<Cell> moveHistory);
        Task<Game> GetGame(Guid mazeId);
        Task<Game> Reset(Guid mazeId);
        Task<MazeBase> GetMaze(Guid mazeId);
    }
}
