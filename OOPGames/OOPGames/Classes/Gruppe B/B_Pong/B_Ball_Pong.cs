using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class B_Ball
    {
        public int ballX 
        {
            get; private set; 
        }
        public int ballY
        {
            get; private set;
        }
        public int radius
        {
            get;
        }
        public float velocityX
        {
            get; set;
        }
        public float velocityY
        {
            get; set;
        }
       

        public B_Ball(int radius, float velocityX, float velocityY)
        {
            ballX = 200;
            ballY = 300;
            this.radius = radius;
            this.velocityX = velocityX;
            this.velocityY = velocityY;
        }

        public void calculate()
        {
            ballX = (int)Math.Round((ballX + velocityX));
            ballY = (int)Math.Round((ballY + velocityY));
        }
    }
}
