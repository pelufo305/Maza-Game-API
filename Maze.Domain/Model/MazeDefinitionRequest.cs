using Maze.Domain.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain.Model
{
    public  class MazeDefinitionRequest : IRequest<ResponseBindingModel<MazeDefinitionResponse>>
    {
        public Guid MazeUid { get; set; }
    }

    public class MazeDefinitionGameRequest : IRequest<ResponseBindingModel<MazeDefinitionGameResponse>>
    {
        public Guid MazeUid { get; set; }
        public Guid GameUid { get; set; }
    }
}
