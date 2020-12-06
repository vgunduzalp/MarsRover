using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            Console.ResetColor();

            var context = new MarsContext();

            context.SendCommand("5 5");
            context.SendCommand("1 2 N");
            context.SendCommand("LMLMLMLMM");
            context.PrintRoverPositionsOnActivePlateau();
            

            context.SendCommand("10 10");
            context.SendCommand("1 2 N");
            context.SendCommand("LMLMLMLMM");
            context.SendCommand("3 3 E");
            context.SendCommand("MMRMMRMRRM");
            context.PrintRoverPositionsOnActivePlateau();



            Console.WriteLine("finish");
            Console.ReadKey();
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var ex = e.ExceptionObject;
            Console.WriteLine("===============EXCEPTION===============");
            Console.WriteLine("Type: " + ex.GetType());
            Console.WriteLine("Message: " + ((Exception)ex).Message);
            
            Console.ReadLine();
        }


    }
}
