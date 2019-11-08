using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace picture
{
    class MyRectangle : MyFigure
    {
        private int width;
        private int height;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public MyRectangle (int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            Width = x2;
            Height = y2;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 10);
            g.DrawRectangle(pen, X, Y, width, height);           
        }

        public override bool isPointInside(int x, int y)
        {
            bool move = false;
            if (x >= X && x <= (X + Width) && y >= Y && y <= (Y + Height)) 
            {
                move = true;
            }
            return move;
        }

        public override void Move(int x, int y)
        {
            X = x;
            Y = y;            
        }
    }
}
