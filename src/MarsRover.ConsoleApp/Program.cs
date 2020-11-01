using MarsRover.Core.Entities;
using MarsRover.Core.ValueObject;
using MarsRover.Domain.Entities;
using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__Test Input:__");
            Console.WriteLine();

            var plateau = new Plataeu();
            plateau.Define("5 5");
            Console.WriteLine(plateau.ToString());

            var roverFirst = new Rover(plateau, "1 2 N");
            Console.WriteLine(roverFirst.StartPosition.ToString());
            roverFirst.SetControlCommands("LMLMLMLMM");
            Console.WriteLine(roverFirst.ControlsString);
            roverFirst.Deploy();

            var roverSecond = new Rover(plateau, "3 3 E");
            Console.WriteLine(roverSecond.StartPosition.ToString());
            roverSecond.SetControlCommands("MMRMMRMRRM");
            Console.WriteLine(roverSecond.ControlsString);
            roverSecond.Deploy();

            Console.WriteLine();
            Console.WriteLine("__Expected Output:__");
            Console.WriteLine();
            Console.WriteLine(roverFirst.ToString());
            Console.WriteLine(roverSecond.ToString());
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
