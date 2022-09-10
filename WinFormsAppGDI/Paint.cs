using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppGDI
{
    public partial class Paint : Form
    {
        //public int OldX { get; set; } = 0;
        //public int OldY { get; set; } = 0;
        public Color Color { get; set; } = Color.Black;
        public int Size { get; set; } = 5;
        public int Index { get; set; }
        public Paint()
        {
            InitializeComponent();
            DrawColorImage();
            toolStripComboBox1.Items.AddRange(Enumerable.Range(1,20).Select(x => x as object).ToArray());
            //toolStripComboBox1.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            toolStripComboBox1.SelectedIndex = Size;
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            //timer.Start();
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
            //Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
            Brush brush = new SolidBrush(Color);
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(brush, 10, 10, 100, 100);
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (State != null)
        //    {
        //        e.Graphics.Restore(State);
        //    }
            
        //    //Random random = new Random();
        //    //var r = random.Next(0, 255);
        //    //var g = random.Next(0, 255);
        //    //var b = random.Next(0, 255);
        //    //Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
        //    //e.Graphics.FillRectangle(brush, 10, 10, 100, 100);
        //}

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics graphics = CreateGraphics();
            //Brush brush = new SolidBrush(Color.Blue);
            //graphics.FillEllipse(brush, e.X, e.Y, 5, 5);
            //if (e.Button == MouseButtons.Left)
            //{
            //    Graphics graphics = CreateGraphics();
            //    Pen pen = new Pen(Color.Red, 5);
            //    graphics.DrawLine(pen, PointOld, e.Location);
            //    //graphics.DrawLine(pen, Point.X, Point.Y, e.X, e.Y);

            //     State = graphics.Save();
            //}
            //PointOld = e.Location;
                //OldX = e.X;
                //OldY = e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //OldX = e.X;
            //OldY = e.Y;
        }

       

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var imageForm = new ImageForm();
            imageForm.MdiParent = this;
            imageForm.Show();
        }

        
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //var fileName = dialog.FileName;
                //var graphics = ActiveMdiChild.CreateGraphics();
                //var width = ActiveMdiChild.Width;
                //var height = ActiveMdiChild.Height;
                //var image = new Bitmap(width, height, graphics);
                //image.Save(fileName);

                var fileName = dialog.FileName;
                var width = ActiveMdiChild.Width;
                var height = ActiveMdiChild.Height;
                Image bmp = new Bitmap(width, height);
                var GG = Graphics.FromImage(bmp);
                var rect = ActiveMdiChild.RectangleToScreen(ActiveMdiChild.ClientRectangle);
                GG.CopyFromScreen(rect.Location, Point.Empty, ActiveMdiChild.Size);
                bmp.Save(fileName, ImageFormat.Png);
                               
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ImageForm imageForm = new ImageForm();
            var graphics = ActiveMdiChild.CreateGraphics();
            graphics.Clear(imageForm.BackColor);
            imageForm.BackColor = Color.White;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           Index = 1;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Index = 2;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Index = 3;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Index = 4;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Index = 5;
        }
    }
}
