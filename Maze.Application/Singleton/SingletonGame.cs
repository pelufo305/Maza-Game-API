using Maze.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Application.Singleton
{
    public  class SingletonGame : ISingletonGame
    {

        private readonly List<GameTransfer> _singletonList = new List<GameTransfer>();


        public void Add(GameTransfer item)
        {
            _singletonList.Add(item);
         }

        public bool Remove(GameTransfer item)
        {
           return _singletonList.Remove(item);
        }

        public List<GameTransfer> GetGameList()
        {
            return _singletonList;
        }
    }



}
