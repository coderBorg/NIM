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
            Console.Clear();
            Console.WriteLine("Hey, it's time to play NIM!");

            NIM_Game theGame = new NIM_Game();
            
            Console.WriteLine("Stones in pile:{0}", theGame.gameStart() );
            
        }
    }
}
