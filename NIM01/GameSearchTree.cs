using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM01
{
    class GameSearchTree
    {
        Random randomGen;
        private Node root, gameStateNode;
        private const int numChildren = 3;
        private int numberOfTreeNodes = 0;

        public GameSearchTree()
        {
            root = new Node(this);
            gameStateNode = root;
            numberOfTreeNodes++;
            randomGen = new Random();
        }

        public void setStartStones(int stones)
        {
            root.gameStateStones = stones;
        }

        public void setIsUserFirst(bool isUserFirst)
        {
            root.gameStateIsUserNextTurn = isUserFirst;
        }

        public void BuildGameTree()
        {
            buildMinMaxTree(root);
        }

        public int getNumberOfNodes()
        {
            return numberOfTreeNodes;
        }


        ////Returns +1 if computer can win
        //private int findComputerMove(Node currentNode)
        //{

        //    if ( currentNode.gameStateStones == 0 )
        //    {
        //        if (currentNode.gameStateIsUserNextTurn) return -1;
        //        else return 1; 
        //    }

        //    if (currentNode.m)

        //    if ( currentNode. )

        //}

        private const bool debugTree = false;

        private void buildMinMaxTree(Node currentNode)
        {
            //If node is leaf then return utility
            if (currentNode.gameStateStones == 0)
            {
                if (currentNode.gameStateIsUserNextTurn) currentNode.miniMax = -1;
                else currentNode.miniMax = 1;
                if (debugTree) Console.WriteLine("Leaf node MiniMax value is {0}", currentNode.miniMax);
                return;
            }

            int loopCount = numChildren;
            if (currentNode.gameStateStones < numChildren) loopCount = currentNode.gameStateStones; 
            for (int childIdx = 0; childIdx < loopCount; childIdx++)
            {
                if ( currentNode.child[childIdx] == null)
                {
                    currentNode.child[childIdx] = new Node(this);
                    currentNode.tree.numberOfTreeNodes++;
                    currentNode.child[childIdx].gameStateIsUserNextTurn = !currentNode.gameStateIsUserNextTurn;
                    currentNode.child[childIdx].gameStateStones = currentNode.gameStateStones - (childIdx + 1);
                }
                buildMinMaxTree(currentNode.child[childIdx]);

            }

            //Find MinMax value
            //if user's turn then node is minimizer node
            if( currentNode.gameStateIsUserNextTurn )
            {
                int minVal = int.MaxValue;
                for (int childIdx = 0; childIdx < loopCount; childIdx++)
                {
                    if (currentNode.child[childIdx].miniMax < minVal) minVal = currentNode.child[childIdx].miniMax;
                }
                currentNode.miniMax = minVal;
                if (debugTree) Console.Write("Minimizer node.");
            } 
            else //node is maximizer node
            {
                int maxVal = int.MinValue;
                for (int childIdx = 0; childIdx < loopCount; childIdx++)
                {
                    if (currentNode.child[childIdx].miniMax > maxVal) maxVal = currentNode.child[childIdx].miniMax;
                }
                currentNode.miniMax = maxVal;
                if (debugTree) Console.Write("Maximizer node.");
            }
            if (debugTree) Console.WriteLine(" MiniMax value is {0}.  {1} stones.", currentNode.miniMax, currentNode.gameStateStones);

        }

        public void userTurn(int stones)
        {
            gameStateNode = gameStateNode.child[stones - 1];
        }

        public int findComputerMove()
        {
            //Find best move
            int max = int.MinValue;
            int turnStones = 1;
            int turnIdx = 0;
            for(int childIdx = 0; childIdx < numChildren; childIdx++)
            {
                if (gameStateNode.child[childIdx] != null)
                {
                    if (gameStateNode.child[childIdx].miniMax >= max)
                    {
                        max = gameStateNode.child[childIdx].miniMax;
                        turnStones = childIdx + 1;
                        turnIdx = childIdx;
                    }
                }
            }

            //If there is no winning move then choose randomly
            if ( max < 1 )
            {
                do
                {
                    turnStones = randomGen.Next(1, numChildren);
                    turnIdx = turnStones - 1;
                } while ( gameStateNode.child[turnIdx] == null ); 
            }

            gameStateNode = gameStateNode.child[turnIdx];
            return turnStones;

        }

        class Node
        {
            //Reference to containing type
            public GameSearchTree tree;

            //Pruning variables
            //public int alpha;
            //public int beta;

            //Minimax value
            public int miniMax;

            //References to parent and children
            public Node parent;
            public Node[] child = new Node[numChildren];
            
            public int gameStateStones { get; set; }
            public bool gameStateIsUserNextTurn { get; set; }

            public Node()
            {
                initRefs();
            }

            public Node(GameSearchTree tree)
            {
                initRefs();
                this.tree = tree;
            }

            public void initRefs()
            {
                for (int i = 0; i < numChildren; i++)
                {
                    child[i] = null;
                }
            }

            public void InsertChild(Node newChild, int childIdx )
            {
                newChild.parent = this;
                child[childIdx] = newChild;
            }
        }

        
    }
}
