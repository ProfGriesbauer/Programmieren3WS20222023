using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class B_Paddle
    {
        public int Id { get; }
        public int paddleX
        {
            get; private set; 
        }
        public int paddleY
        {
            get; private set; 
        }
        public float stepsize
        {
            get; set;
        }
        public int lineThickness
        {
            get;
        }
        public int lineWidth
        {
            get;
        }
        public B_Paddle(int id, bool isBottom)
        {
            Id = id;

            if(isBottom)
            {
                paddleY = 520;
            }
            else
            {
                paddleY = 80;
            }
            
            paddleX = 100;
            stepsize = 1;
            lineThickness = 10;
            lineWidth = 75;
        }

        public void calculate()
        {
            paddleX = (int)Math.Round(paddleX + stepsize);
        }
    }
}
