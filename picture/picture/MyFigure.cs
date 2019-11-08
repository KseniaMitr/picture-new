using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace picture
{
    class MyFigure
    {
        private int x;
        private int y;      
       

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set {y = value; }
        }

        public virtual void Draw(Graphics g)
        {
        }

        public virtual bool isPointInside(int x,int y)
        {
            bool move = false;
            return  move;
        }

        public virtual void Move(int x, int y)
        {

        }

    }
}
