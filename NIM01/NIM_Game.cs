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

        public int gameStart()
        {
            Random randomGen = new Random();
            stoneCount = randomGen.Next(1, maxNumStones);

            return stoneCount;
        }

        public void setIsUserFirst(bool isUserFirst)
        {
            this.isUserFirst = isUserFirst;
        }

        public bool getIsUserFirst()
        {
            return this.isUserFirst;
        }
    }
}
