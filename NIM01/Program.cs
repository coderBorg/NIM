using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcom message
            Console.Clear();
            Console.WriteLine("Hey, it's time to play NIM!");

            //Intantiate the game
            NIM_Game theGame = new NIM_Game();
            
            //Tell user the number of stones in the pile
            Console.WriteLine("Stones in pile:{0}", theGame.gameStart() );

            //Who goes first
            Console_Input userInput = new Console_Input();
            Console.Write("Do you want to go first?");
            bool isUserFirst = userInput.getYesOrNo();
            Console.WriteLine();
            if (isUserFirst)
                Console.WriteLine("User goes first.");
            else
                Console.WriteLine("Computer goes first.");

        }
    }
}
