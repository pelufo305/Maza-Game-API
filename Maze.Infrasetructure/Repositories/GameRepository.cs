using Maze.Domain.Entities;
using Maze.Domain.Repository;
using Maze.Infrasetructure.Base;
using Maze.Infrasetructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Maze.Infrasetructure.Repositories
{
    public  class GameRepository: IGameRepository
    {
        private readonly PersistenceContext _applicationDbContext;


        public GameRepository(PersistenceContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public  async Task<Game> addGame(Game game)
        {
            var result = await new Repository<Game>(_applicationDbContext).AddAsync(new Game()
            {
                MazeUid = game.MazeUid,
                GameUid = game.GameUid,
            });
            return result;
        }

        public async Task<MazeBase> addMaze(MazeBase maze)
        {
            var result = await new Repository<MazeBase>(_applicationDbContext).AddAsync(new MazeBase()
            {
                MazeUid = maze.MazeUid,
                Height = maze.Height,
                Width = maze.Width
            });
            return result;
        }


        public async Task<MazeBase> GetMaze(Guid mazeId)
        {
            var result = await _applicationDbContext.MazeBase.Where(x => x.MazeUid == mazeId).FirstAsync();
            return result;
        }

        public async Task<Game> GetGame(Guid mazeId)
        {
            var result = await _applicationDbContext.Game.Where(x => x.MazeUid == mazeId ).FirstAsync();
            return result;
        }

        public async Task<Game> Reset(Guid mazeId)
        {
            var result = await _applicationDbContext.Game.Where(x => x.MazeUid == mazeId).FirstAsync();
           // result.moveHistory = new List<Cell>();
            var rest = await _applicationDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Game> UpdatemoveHistory(Guid mazeUid, List<Cell> moveHistory)
        {
            var result =  await _applicationDbContext.Game.Where(x => x.MazeUid == mazeUid).FirstAsync();
           // result.moveHistory = moveHistory;
            var rest = await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
