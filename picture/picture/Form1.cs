using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picture
{
    public partial class drawing_machine : Form
    {
        public drawing_machine()
        {
            InitializeComponent();
        }
        
        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        List<MyFigure> figure = new List<MyFigure>();
        int currentAction = 0;
        int startX = 0;
        int startY = 0;       
        bool move = false;
        MyFigure currentMoveFigure;
        enum buttonPress { rectangle, circle, vagon};            

        public void DrawRectangle(int x, int y, int width, int height)
        {
            Graphics g = CreateGraphics();
            MyRectangle rect = new MyRectangle(x, y, width, height);
            figure.Add(rect);
        }

        public void DrawCircle(int x, int y, int rad)
        {
            Graphics g = CreateGraphics();
            MyCircle circ = new MyCircle(x, y, rad);
            figure.Add(circ);
        }

        public void DrawVagon(int x, int y, int wid, int heig)
        {
            Graphics g = CreateGraphics();
            MyVagon vagon = new MyVagon(x, y, wid, heig);
            figure.Add(vagon);
        }


        private void RectBut_Click(object sender, EventArgs e)
        {
            currentAction = (int)buttonPress.rectangle;
            move = false;
        }

        private void CirclBut_Click(object sender, EventArgs e)
        {
            currentAction = (int)buttonPress.circle;
            move = false;
        }        

        private void butVagon_Click(object sender, EventArgs e)
        {
            currentAction = (int)buttonPress.vagon;
            move = false;
        }
        private void butMoving_Click(object sender, EventArgs e)
        {
            currentAction = -1;
        }

        private void drawing_machine_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            foreach (MyFigure rect in figure)
            {
                rect.Draw(g);
            }

            foreach (MyFigure circ in figure)
            {
                circ.Draw(g);
            }

            foreach (MyFigure vagon in figure)
            {
                vagon.Draw(g);
            }
        }   
        
        private void drawing_machine_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.Location.X;
            startY = e.Location.Y;

            if (currentAction == -1)
            {
                foreach (MyFigure fig in figure)
                {
                    if (fig.isPointInside(e.X, e.Y))
                    {
                        currentMoveFigure = fig;
                        move = true;
                    }
                }
            }
        }          
       

        private void drawing_machine_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentAction)
            {
                case 0:
                    if (startX < e.Location.X && startY < e.Location.Y)
                        DrawRectangle(startX, startY, e.Location.X - startX, e.Location.Y - startY);

                    if (startX > e.Location.X && startY < e.Location.Y)
                        DrawRectangle(e.Location.X, startY, startX - e.Location.X, e.Location.Y - startY);

                    if (startX > e.Location.X && startY > e.Location.Y)
                        DrawRectangle(e.Location.X, e.Location.Y, startX - e.Location.X, startY - e.Location.Y);

                    if (startX < e.Location.X && startY > e.Location.Y)
                        DrawRectangle(startX, e.Location.Y, e.Location.X - startX, startY - e.Location.Y);
                    break;

                case 1:
                    int xrad = Math.Abs(startX - e.Location.X);
                    int yrad = Math.Abs(startY - e.Location.Y);
                    int rad = (int)Math.Sqrt(Math.Pow(xrad, 2) + Math.Pow(yrad, 2));
                    DrawCircle(startX - rad, startY - rad, rad);
                    break;

                case 2:
                    if (startX < e.Location.X && startY < e.Location.Y)
                        DrawVagon(startX, startY, e.Location.X - startX, e.Location.Y - startY);

                    if (startX > e.Location.X && startY < e.Location.Y)
                        DrawVagon(e.Location.X, startY, startX - e.Location.X, e.Location.Y - startY);

                    if (startX > e.Location.X && startY > e.Location.Y)
                        DrawVagon(e.Location.X, e.Location.Y, startX - e.Location.X, startY - e.Location.Y);

                    if (startX < e.Location.X && startY > e.Location.Y)
                        DrawVagon(startX, e.Location.Y, e.Location.X - startX, startY - e.Location.Y);
                    break;
            }

            if (move)    
                currentMoveFigure.Move(e.Location.X, e.Location.Y);
            
            Refresh();
        }
       
    }
}
