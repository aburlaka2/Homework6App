using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6App
{
    public class Player
    {
        public char Char { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public bool isAlive { get; set; }
        public Player()
        {
            Char = '☻';
            xPos = 0;
            yPos = 0;
            isAlive = true;
        }
        public void GetInfo()
        {
            Console.WriteLine(xPos);
        }
    }
}
