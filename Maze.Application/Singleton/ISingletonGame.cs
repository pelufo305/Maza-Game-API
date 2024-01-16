using Maze.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Application.Singleton
{
    public  interface ISingletonGame
    {
        List<GameTransfer> GetGameList();
        void Add(GameTransfer item);

        bool Remove(GameTransfer item);

    }
}
