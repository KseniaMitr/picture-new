using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace picture
{
    class MyCircle : MyFigure
    {      
        private int radius;
       
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public MyCircle(int x, int y, int rad )
        {
            X = x;
            Y = y;            
            radius = rad;
        }

        public override void Draw(Graphics g)  
        {
            Pen pen = new Pen(Color.Black, 10);
            g.DrawEllipse(pen, X, Y, 2 * radius, 2 * radius);                 
        }

        public override bool isPointInside(int x, int y)
        {
            bool move = false;
            int xZentr = X + radius;
            int yZentr = Y + radius;

            int xNowrad = Math.Abs(xZentr - x);
            int yNowrad = Math.Abs(yZentr - y);
            int Nowrad = (int)Math.Sqrt(Math.Pow(xNowrad, 2) + Math.Pow(yNowrad, 2));

            if (Nowrad <= radius) move = true;

            return move;
        }

        public override void Move(int x, int y)
        {
            X = x - radius;
            Y = y - radius;
        }

    }
}
