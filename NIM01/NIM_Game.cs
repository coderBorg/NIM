/*!   \NIM_Game.cs
      \author  Jeff Borg
      \details
      AI class at Apollo \n
      NIM game \n
      24 Jan 2016 \n
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM01
{
    class NIM_Game
    {
        int stoneCount;
        const int maxNumStones = 30;
        const int minTurnStones = 1;
        const int maxTurnStones = 3;
        bool isUserFirst;
        bool isUserTurn;
        Random randomGen;

        public NIM_Game()
        {
            randomGen = new Random();
        }

        public int gameStart()
        {
            Random randomGen = new Random();
            stoneCount = randomGen.Next(1, maxNumStones);

            return stoneCount;
        }

        public void setIsUserFirst(bool isUserFirst)
        {
            this.isUserFirst = isUserFirst;
            this.isUserTurn = isUserFirst;
        }

        public bool getIsUserFirst()
        {
            return this.isUserFirst;
        }

        public bool isGameOver()
        {
            return stoneCount == 0;
        }

        public bool getIsUserTurn()
        {
            return this.isUserTurn;
        }

        public bool userTurn(int stones)
        {
            if (stoneCount - stones >= 0)
            {
                stoneCount -= stones;
                this.isUserTurn = false;
                return true;
            }
            else
                return false;
            
        }

        //Function:  computerTurn()
        //Description:  Computes computer's move and returns it.
        //Preconditions:  It is in fact the computer's turn.
        //Postconditions:  Computer's turn is executed and value returned.
        public int computerTurn()
        {
            
            int computerTurn;

            //Next turn will be the user's
            isUserTurn = true;

            //Strategy is to leave opponent with 4n+1 stones where n is an integer >= 0
            computerTurn = (stoneCount - 1) % (maxTurnStones + 1);

            //If move is legal execute it
            if (computerTurn > 0)
            {
                stoneCount -= computerTurn;
                return computerTurn;
            }

            //If there is no optimal move then choose move at random
            do
            {
                computerTurn = randomGen.Next( minTurnStones, maxTurnStones );
            } while ( computerTurn > stoneCount );
            stoneCount -= computerTurn;
            return computerTurn;
        }

        public int getNumStones()
        {
            return stoneCount;
        }

    }
}
