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

            //Intantiate the game and user input utility
            NIM_Game theGame = new NIM_Game();
            Console_Input userInput = new Console_Input();

            //Tell user the number of stones in the pile
            Console.WriteLine("Stones in pile:{0}", theGame.gameStart() );

            //Who goes first
            Console.Write("Do you want to go first?");
            bool isUserFirst = userInput.getYesOrNo();
            Console.WriteLine();
            if (isUserFirst)
                Console.WriteLine("User goes first.");
            else
                Console.WriteLine("Computer goes first.");
            theGame.setIsUserFirst(isUserFirst);
            Console.WriteLine(theGame.getIsUserFirst());//test

            do
            {
                if ( theGame.getIsUserTurn() )
                {
                    Console.Write("User's turn, how many stones do you take?");
                    theGame.userTurn(userInput.getIntInRange(1, 3));
                }
                else
                {
                    Console.WriteLine("Computer's turn, Computer takes {0} stones", theGame.computerTurn());
                }
                Console.WriteLine("Stones in pile: {0}", theGame.getNumStones());

            } while ( !theGame.isGameOver() );

            if (theGame.getIsUserTurn())
                Console.WriteLine("You win!");
            else
                Console.WriteLine("Computer wins!");
        }
    }
}
