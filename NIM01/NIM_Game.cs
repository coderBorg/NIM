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
        bool isUserFirst;
        bool isUserTurn;

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

        public void userTurn(int stones)
        {
            if (stoneCount - stones >= 0) stoneCount -= stones;
            this.isUserTurn = false;
        }

        public int computerTurn()
        {
            Random randomGen = new Random();
            int computerTurn;
            do
            {
                computerTurn = randomGen.Next(1, 3);
            } while (computerTurn > stoneCount);
            stoneCount -= computerTurn;
            this.isUserTurn = true;
            return computerTurn;
        }

        public int getNumStones()
        {
            return stoneCount;
        }

    }
}
