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

            while (angle < 2 * Math.PI)
            {
                int x = (int)(w * Math.Cos(angle)) + p1.X;
                int y = (int)(h * Math.Sin(angle)) - p1.Y + bitmapYSize;
                bitmap.SetPixel(x, y, color);
                angle += Math.PI / 720.0;
            }
;
        }
    }
}
