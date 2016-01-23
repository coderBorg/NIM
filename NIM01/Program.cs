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
            Console.Write("Do you want to go first?");
            char userInput;
            bool isUserFirst = false;
            bool isInputValid = false;
            do
            {
                userInput = Console.ReadKey().KeyChar;
                if ((userInput == 'Y') || (userInput == 'y'))
                {
                    isUserFirst = true;
                    isInputValid = true;
                }
                else if ((userInput == 'N') || (userInput == 'n'))
                {
                    isUserFirst = false;
                    isInputValid = true;
                }
                else
                {
                    isInputValid = false;
                    Console.WriteLine();
                    Console.WriteLine("Invalid Input");
                }
                    
            } while (!isInputValid);

            Console.WriteLine();

            if (isUserFirst)
                Console.WriteLine("User goes first.");
            else
                Console.WriteLine("Computer goes first.");

        }
    }
}
