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

        public ImageForm()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBoxImage.Image = bitmap;
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
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

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            var color = (ParentForm as Paint).Color;
            var size = (ParentForm as Paint).Size;
            var index = (ParentForm as Paint).Index;
            Pen penC = new Pen(color, size);
            Graphics graphics = e.Graphics;
            if (index == 3) graphics.DrawEllipse(penC, cX, cY, sX, sY);
            if (index == 4) graphics.DrawRectangle(penC, cX, cY, sX, sY);
            if (index == 5) graphics.DrawLine(penC, cX, cY, x, y);
        }

       

        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            PointOld = e.Location;

            //OldX = e.X;
            //OldY = e.Y;
            cX = e.X;
            cY = e.Y;
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
            if (index == 3) graphics.DrawEllipse(penC, cX, cY, sX, sY);
            if (index == 4) graphics.DrawRectangle(penC, cX, cY, sX, sY);
            if (index == 5) graphics.DrawLine(penC, cX, cY, x, y);

        }
    }
}
