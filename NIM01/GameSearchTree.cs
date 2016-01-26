using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM01
{
    class GameSearchTree
    {

        private Node root, gameStateNode;

        public void GameSearchTree()
        {
            Node root = new Node(this);
            gameStateNode = root;        
        }

        public void setStartStones(int stones)
        {
            root.gameStateStones = stones;
        }

        public void setIsUserFirst(bool isUserFirst)
        {
            root.gameStateIsUserNextTurn = isUserFirst;
        }

        //Returns +1 if computer can win
        private int depthSearch(Node currentNode)
        {
            if ( currentNode.gameStateStones == 0 )
            {
                if (currentNode.gameStateIsUserNextTurn) return -1;
                else return 1; 
            }

            if (currentNode.m)

            if ( currentNode. )

        }

        class Node
        {
            //Reference to containing type
            private GameSearchTree tree;

            //Pruning variables
            public int alpha;
            public int beta;

            //Minimax value
            public int miniMax;

            //References to parent and children
            public Node parent;
            public Node[] child = new Node[3];
            
            public int gameStateStones { get; set; }
            public bool gameStateIsUserNextTurn { get; set; }

            public Node()
            {
            }

            public Node(GameSearchTree tree)
            {
                this.tree = tree;
            }

            public void InsertChild(Node newChild, int childIdx )
            {
                newChild.parent = this;
                child[childIdx] = newChild;
            }
        }

        
    }
}
