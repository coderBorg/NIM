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
        bool isTreeBuilt = false;
        Random randomGen;
        GameSearchTree theSearchTree;

        public NIM_Game()
        {
            randomGen = new Random();
            theSearchTree = new GameSearchTree();
        }

        public int gameStart()
        {
            //Random randomGen = new Random();
            //stoneCount = randomGen.Next(1, maxNumStones);
            //stoneCount = 17;//debug
            stoneCount = randomGen.Next(1, 29);//debug
            theSearchTree.setStartStones(stoneCount);

            return stoneCount;
        }

        public void setIsUserFirst(bool isUserFirst)
        {
            this.isUserFirst = isUserFirst;
            this.isUserTurn = isUserFirst;
            theSearchTree.setIsUserFirst(isUserFirst);
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
                theSearchTree.userTurn(stones);
                return true;
            }
            else
                return false;
            
        }

        public void setUpGame()
        {
            if (!isTreeBuilt) theSearchTree.BuildGameTree();
            Console.WriteLine("Number of Nodes in MinMax tree: {0}", theSearchTree.getNumberOfNodes());
            isTreeBuilt = true;
        }

        //Function:  computerTurn()
        //Description:  Computes computer's move and returns it.
        //Preconditions:  It is in fact the computer's turn.
        //Postconditions:  Computer's turn is executed and value returned.
        public int computerTurn()
        {
            
            int computerTurn;

            const int strategyMinMax = 2;
            const int computerStrategy = strategyMinMax;


            //Next turn will be the user's
            isUserTurn = true;


            if ( computerStrategy == strategyMinMax )
            {
               

                //add find turn call
                computerTurn =  theSearchTree.findComputerMove();
                stoneCount -= computerTurn;
                return computerTurn;
            }

            ////Strategy is to leave opponent with 4n+1 stones where n is an integer >= 0
            //computerTurn = (stoneCount - 1) % (maxTurnStones + 1);

            ////If move is legal execute it
            //if (computerTurn > 0)
            //{
            //    stoneCount -= computerTurn;
            //    return computerTurn;
            //}

            ////If there is no optimal move then choose move at random
            //do
            //{
            //    computerTurn = randomGen.Next( minTurnStones, maxTurnStones );
            //} while ( computerTurn > stoneCount );
            //stoneCount -= computerTurn;
            //return computerTurn;

        }//************END METHOD

        public int getNumStones()
        {
            return stoneCount;
        }

    }
}
