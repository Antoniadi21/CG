using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class Form1 : Form
    {

        private int bitmapXSize = 500;
        private int bitmapYSize = 500;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(bitmapXSize, bitmapYSize);
            drawEllipse(new Point(200, 250), 70, 120, bitmap, Color.Magenta);
            pictureBox1.Image = bitmap;
        }



        private void drawEllipse(Point p1, int h, int w, Bitmap bitmap, Color color)
        {
            //double angle = 0;

            //while (angle < Math.PI / 2)
            //{
            //    int x = (int)(w * Math.Cos(angle));
            //    int y = (int)(h * Math.Sin(angle));
            //    drawPixels(bitmap, p1.X, p1.Y, x, y, color);
            //    angle += Math.PI / 720.0;
            //}

            int x = 0;
            int y = h;

            int delta = 4 * h * h * (x + 1) * (x + 1) + w * w * (2 * y - 1) * (2 * y - 1) - 4 * w * w * h * h;
            while (w * w * (2 * y - 1) > 2 * h * h * (x + 1))
            {
                drawPixels(bitmap, p1.X, p1.Y, x, y, color);
                if (delta < 0)
                {
                    x++;
                    delta += 4 * h * h * (2 * x + 3);
                }
                else
                {
                    x++;
                    delta += -8 * w * w * (y - 1) + 4 * h * h * (2 * x + 3);
                    y--;

                }
            }

            delta = h * h * (2 * x + 1) * (2 * x + 1) + 4 * w * w * (y + 1) * (y + 1) - 4 * w * h;
            while (y + 1 != 0)
            {
                drawPixels(bitmap, p1.X, p1.Y, x, y, color);
                if (delta < 0)
                {
                    y--;
                    delta += 4 * w * w * (2 * y + 3);
                }
                else
                {
                    y--;
                    delta += -8 * h * h * (x + 1) + 4 * w * w * (2 * y + 3);
                    x++;
                }
            }
        }




        private void drawPixels(Bitmap bitmap, int x0, int y0, int x, int y, Color color) 
        {
            bitmap.SetPixel(x0 + x, bitmapYSize - y0 + y, color);
            bitmap.SetPixel(x0 - x, bitmapYSize - y0 - y, color);
            bitmap.SetPixel(x0 + x, bitmapYSize - y0 - y, color);
            bitmap.SetPixel(x0 - x, bitmapYSize - y0 + y, color);
        }
    }
}
