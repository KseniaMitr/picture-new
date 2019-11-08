using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace picture
{
    class MyVagon: MyRectangle
    {
        MyCircle wheel1 = new MyCircle(0, 0, 0);
        MyCircle wheel2 = new MyCircle(0, 0, 0);


        public MyVagon(int x, int y, int widht, int height) : base (x, y, x + widht, y + height)
        {
            X = x;
            Y = y;
            Width = widht;
            Height = height;

            int radCirc = Width / 10;

            int xCirc1 = X + radCirc;
            int xCirc2 = X + radCirc+ 3 * Width / 5;
            int yCirc = Y + Height - radCirc;           

            wheel1.X = xCirc1;
            wheel1.Y = yCirc;
            wheel1.Radius = radCirc;

            wheel2.X = xCirc2;
            wheel2.Y = yCirc;
            wheel2.Radius = radCirc;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            wheel1.Draw(g);
            wheel2.Draw(g);
        }

        public override bool isPointInside(int x, int y)
        {         
            bool move = false;
            if (x >= X && x <= (X + Width) && y >= Y && y <= (Y + Height))
            {
                move = true;                              /////проверка нажатия на прямоуг.
            }      
            return move;
        }

        public override void Move(int x, int y)
        {
            // Перемещаем каждый объект из котоого состоит вагон.

            base.Move(x, y);

            //  Расчитать новые координаты для первого колеса
            int wheel1NewX = x + 2*wheel1.Radius;
            int wheel1NewY = y + base.Height;            

            //  Расчитать новые координаты для второго колеса
            int wheel2NewX = x + 2*wheel2.Radius + 3* base.Width/5;
            int wheel2NewY = y + base.Height;

            wheel1.Move(wheel1NewX, wheel1NewY);
            wheel2.Move(wheel2NewX, wheel2NewY);
        }

    }
}
