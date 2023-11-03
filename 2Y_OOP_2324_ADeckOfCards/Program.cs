using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            Console.WriteLine("cards have been generated. press any key to start the game");
            Console.ReadKey();
            Game.Gameplay();
        }
    }
}
