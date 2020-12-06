using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Commands.Interfaces
{
    public interface ICommand
    {
        void RunCommand(Plateau plateau);
    }
}
