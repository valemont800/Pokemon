using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class Player
    {
        public int x, y;
        public int speed = 6;
        public int height = 10;
        public int width = 8;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(string direction)
        {
            if(direction == "up")
            {
                y -= speed;
                if(y == 600) //hits the wall
                {
                    y = 600;
                }
            }

            if(direction == "down")
            {
                y += speed;
                if(y == 0)
                {
                    y = 0;
                }
            }
            
            if(direction == "left")
            {
                x -= speed;
                if(x == 0)
                {
                    x = 0;
                }
            }

            if(direction == "right")
            {
                x += speed;
                if(x == 1100)
                {
                    x = 1100;
                }
            }
        }
    }
}
