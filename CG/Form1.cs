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
            drawEllipse(new Point(200, 300), 70, 120, bitmap, Color.Magenta);
            pictureBox1.Image = bitmap;
        }



        private void drawEllipse(Point p1, int h, int w, Bitmap bitmap, Color color)
        {
            double angle = 0;

            while (angle < Math.PI / 2)
            {
                int x = (int)(w * Math.Cos(angle));
                int y = (int)(h * Math.Sin(angle));
                drawPixels(bitmap, p1.X, p1.Y, x, y, color);
                angle += Math.PI / 720.0;
            }
;
        }

        private void drawPixels(Bitmap bitmap, int x0, int y0, int x, int y, Color color) 
        {
            bitmap.SetPixel(x0 + x, bitmapYSize - y0 + y, color);
            bitmap.SetPixel(x0 - x, bitmapYSize - y0 - y, color);
            bitmap.SetPixel(x0 + x, bitmapYSize - y0 - y, color);
            bitmap.SetPixel(x0 - x, bitmapYSize - y0 + y, color );
        }
    }
}
