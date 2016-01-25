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

        //Returns true if User is winner
        private bool depthSearch(Node startNode)
        {
            if ( startNode.gameStateStones ==0 )
            {
                return 
            }
        }

        class Node
        {
            //Reference to containing type
            private GameSearchTree tree;

            //Pruning variables
            public int alpha;
            public int beta; 

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
