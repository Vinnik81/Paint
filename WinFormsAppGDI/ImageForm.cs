using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppGDI
{
    public partial class ImageForm : Form
    {
        public Point PointOld { get; set; }
        public GraphicsState State { get; set; }
        int x, y, sX, sY, cX, cY;
        Bitmap bitmap;
        Color newColor;

        public ImageForm()
        {
            InitializeComponent();
           
        }

       

        private void ImageForm_MouseDown(object sender, MouseEventArgs e)
        {
            PointOld = e.Location;
            
            //OldX = e.X;
            //OldY = e.Y;
            cX = e.X;
            cY = e.Y;
           
        }

        
        private void ImageForm_MouseUp(object sender, MouseEventArgs e)
        {
            
            var color = (ParentForm as Paint).Color;
            var size = (ParentForm as Paint).Size;
            var index = (ParentForm as Paint).Index;
            Graphics graphics = CreateGraphics();
            Pen penC = new Pen(color, size);
            penC.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penC.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            sX = x - cX;
            sY = y - cY;
            if (index == 3) graphics.DrawEllipse(penC, cX, cY, sX, sY);
            if (index == 4) graphics.DrawRectangle(penC, cX, cY, sX, sY);
            if (index == 5) graphics.DrawLine(penC, cX, cY, x, y);

        }

        private void ImageForm_MouseMove(object sender, MouseEventArgs e)
        {
            var color = (ParentForm as Paint).Color;
            var size = (ParentForm as Paint).Size;
            var index = (ParentForm as Paint).Index;
            Graphics graphics = CreateGraphics();
            
            if (e.Button == MouseButtons.Left)
            {
                switch (index)
                {
                    case 1:
                        Pen penP = new Pen(color, size);
                        penP.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        penP.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        graphics.DrawLine(penP, PointOld, e.Location);
                        //graphics.DrawLine(pen, Point.X, Point.Y, e.X, e.Y);
                        break;
                    case 2:
                        Pen penE = new Pen(Color.White, size);
                        penE.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        penE.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        graphics.DrawLine(penE, PointOld, e.Location);
                        break;
                    case 3:
                        x = e.X;
                        y = e.Y;
                        sX = e.X - cX;
                        sY = e.Y - cY;
                        break;
                    case 4:
                        x = e.X;
                        y = e.Y;
                        sX = e.X - cX;
                        sY = e.Y - cY;
                        break;
                    case 5:
                        x = e.X;
                        y = e.Y;
                        sX = e.X - cX;
                        sY = e.Y - cY;
                        break;
                    default:
                        break;
                }
                State = graphics.Save();
            }
            PointOld = e.Location;
            
        }
        private void ImageForm_Paint(object sender, PaintEventArgs e)
        {
            var color = (ParentForm as Paint).Color;
            var size = (ParentForm as Paint).Size;
            var index = (ParentForm as Paint).Index;
            Pen penC = new Pen(color, size);
            Graphics graphics = e.Graphics;
            if (index == 3)
            {
                graphics.DrawEllipse(penC, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                graphics.DrawRectangle(penC, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                graphics.DrawLine(penC, cX, cY, x, y);
            }
        }

        static Point set_point(ImageForm imF, Point pt)
        {
            float pX =  imF.ClientSize.Width / imF.Width;
            float pY =  imF.ClientSize.Height / imF.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY)); 
        }
        private void Validate(Bitmap bm, Stack<Point> sp, int x, int y)
        {
            var color = (ParentForm as Paint).Color;
            Color cx = bm.GetPixel(x, y);
            if (cx == color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, color);
            }
        }
        public void Fill(Bitmap bm, int x, int y)
        {
            var color = (ParentForm as Paint).Color;
            Stack<Point> pixel = new Stack<Point>();
            Color oldColor = bm.GetPixel(x, y);
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, color);
            if (oldColor == color) return;
            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    Validate(bm, pixel, pt.X - 1, pt.Y);
                    Validate(bm, pixel, pt.X, pt.Y - 1);
                    Validate(bm, pixel, pt.X + 1, pt.Y);
                    Validate(bm, pixel, pt.X, pt.Y + 1);
                }
            }
        }

        private void ImageForm_MouseClick(object sender, MouseEventArgs e)
        {
            var color = (ParentForm as Paint).Color;
            var size = (ParentForm as Paint).Size;
            var index = (ParentForm as Paint).Index;
            var imF = new ImageForm();
            var bm = new Bitmap(500, 500);
            if (index == 6)
            {
                Point point = set_point(imF, e.Location);
                Fill(bm, point.X, point.Y);             
            }
             
        }
    }
}
