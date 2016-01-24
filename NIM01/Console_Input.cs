using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM01
{
    class Console_Input
    {
        public bool getYesOrNo()
        {
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
            return isUserFirst;
        }

        public int getIntInRange(int min, int max)
        {
            string userInput;
            int userInt;
            do
            {
                userInput = Console.ReadLine();
                if ( Int32.TryParse(userInput, out userInt) )
                {
                    if ((userInt >= min) && (userInt <= max)) return userInt;
                    else
                        Console.WriteLine("Invalid Input");
                }
                else
                    Console.WriteLine("Invalid Input");
                
            } while (true);
          
        }
    }
}
