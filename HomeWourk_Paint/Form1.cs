using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWourk_Paint
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        public Color Color { get; set; } = Color.Black;
        Pen Ereaser = new Pen(Color.White, 20);
        public new int Size { get; set; } = 5;
        public int Index { get; set; }
        int x, y, sX, sY, cX, cY;
        Color New_Color;

        public Form1()
        {
            InitializeComponent();
            DrawColorImage();
            toolStripComboBox1.Items.AddRange(Enumerable.Range(1, 20).Select(x => x as object).ToArray());
            toolStripComboBox1.SelectedIndex = Size;
            bm = new Bitmap(pictureBoxPaint.Width, pictureBoxPaint.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pictureBoxPaint.Image = bm;
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void DrawColorImage()
        {
            var image = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color);

            toolStripButton1.Image = image;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            var r = random.Next(0, 255);
            var g = random.Next(0, 255);
            var b = random.Next(0, 255);
            Brush brush = new SolidBrush(Color);
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(brush, 10, 10, 100, 100);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            Size = toolStripComboBox1.SelectedIndex;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color = dialog.Color;
                DrawColorImage();
            }
            Pen p = new Pen(Color, Size);
            New_Color = dialog.Color;
            pictureBoxPaint.BackColor = dialog.Color;
            p.Color = dialog.Color;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Index = 4;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Index = 5;
        }

        private void pictureBoxPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color, Size);
            if (paint)
            {
                if (Index == 3) g.DrawEllipse(p, cX, cY, sX, sY);
                if (Index == 4) g.DrawRectangle(p, cX, cY, sX, sY);
                if (Index == 5) g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBoxPaint.Image = bm;
            Index = 0;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Index = 6;
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            if (paint)
            {
                if(e.Button == MouseButtons.Left)
                { 
                    if (Index == 1)
                    {
                   Pen p = new Pen(Color, Size);
                   p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                   p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                   px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                    }
                    if (Index == 2)
                    {
                   Ereaser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                   Ereaser.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                   px = e.Location;
                    g.DrawLine(Ereaser, px, py);
                    py = px;
                    }
                }
            }
            pictureBoxPaint.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            Pen p = new Pen(Color, Size);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            sX = x - cX;
            sY = y - cY;
            if (Index == 3) g.DrawEllipse(p, cX, cY, sX, sY);
            if (Index == 4) g.DrawRectangle(p, cX, cY, sX, sY);
            if (Index == 5) g.DrawLine(p, cX, cY, x, y);
        }

        private void pictureBoxPaint_MouseClick(object sender, MouseEventArgs e)
        {
            if (Index == 6)
            {
                Point point = set_Point(pictureBoxPaint, e.Location);
                Fill(bm, point.X, point.Y, New_Color);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg|*.jpg|(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bm.Clone(new Rectangle(0, 0, pictureBoxPaint.Width, pictureBoxPaint.Height), bm.PixelFormat);
                btm.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Хотите сохраннить данные?", "MyPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else if (res == DialogResult.No)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Index = 2;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Index = 3;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Index = 1;
        }

        static Point set_Point(PictureBox pb, Point pt)
        {
            float px = 1f * pb.Width / pb.Width;
            float py = 1f * pb.Height / pb.Height;
            return new Point((int)(pt.X * px), (int)(pt.Y * py));
        }

        private void Validate(Bitmap bm, Stack<Point>sp, int x, int y, Color Old_Color, Color New_Color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == Old_Color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, New_Color);
            }
        }

        public void Fill(Bitmap bm, int x, int y, Color New_Clr)
        {
            Color Old_Color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, New_Clr);
            if (Old_Color == New_Clr) return;
            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    Validate(bm, pixel, pt.X - 1, pt.Y, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X, pt.Y - 1, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X + 1, pt.Y, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X, pt.Y + 1, Old_Color, New_Clr);
                }
            }
        }
    }
}
