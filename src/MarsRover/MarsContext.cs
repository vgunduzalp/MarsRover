using MarsRover.Commands;
using MarsRover.Exceptions;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class MarsContext
    {
        public List<Plateau> PlateauList { get; set; } = new List<Plateau>();
        public Plateau ActivePlateau { get; set; }
        
        public void SendCommand(Guid plateauId, string command)
        {
            var find = PlateauList.SingleOrDefault(a => a.Id == plateauId);
            if (find == null)
            {
                throw new MarsRoverException("Plateau not found");
            }
            ActivePlateau = find;
            SendCommand(command);
        }

        public Plateau SendCommand(string command)
        {
            var myCommand = CommandFactory.GetCommand(command);

            //if command is SetPlateauSizeCommand, new plateau must be added 
            if (myCommand is SetPlateauSizeCommand)
            {
                ActivePlateau = AddPlateau();
            }

            if (ActivePlateau == null)
                throw new MarsRoverException("Plateau not found, please send command eg: 5 5 for add a new plateau");

            myCommand.RunCommand(ActivePlateau);

            return ActivePlateau;
        }

        public void PrintRoverPositionsOnActivePlateau()
        {
            Console.WriteLine($"ActivePlateauId: {ActivePlateau.Id.ToString()}");
            foreach (var item in ActivePlateau.RoverList)
            {
                Console.WriteLine(item.Position.ToString());
            }

        }

        private Plateau AddPlateau()
        {
            var plateau = new Plateau();
            PlateauList.Add(plateau);
            return plateau;
        }

    }
}
