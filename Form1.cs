using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Timer
{


    public partial class Form1 : Form
    {
        private void From_Paint(object sender, PaintEventArgs e)
        {
            int w, h;
            string s;
            w = this.Width;
            h = this.Height;
            DateTime dt = DateTime.Now;
    
            Pen cir_pen = new Pen (Color.Green, 2);
            Brush brush = new SolidBrush(Color.Red);
            Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            Graphics g = e.Graphics;

            GraphicsState gs;

            g.TranslateTransform(w / 2, h / 2);
            g.ScaleTransform(w / 300, h / 300);

            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
         


            gs = g.Save();
            g.RotateTransform(6 * (dt.Minute+(float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Red), 4), 0, 0, 0, -70);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * (dt.Second));
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, 0, 0, -80);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute/60 ));
            g.DrawLine(new Pen(new SolidBrush(Color.Red), 6), 0, 0, 0, -60);
            g.Restore(gs);



            for (int i = 0; i < 60; i++)
            {
                gs = g.Save();
                g.RotateTransform(6 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black),3), 0, 150, 0, 150);

                g.Restore(gs);
            }
            for (int i = 0; i < 12; i++)
            {
                gs = g.Save();
                g.RotateTransform(30 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), 0, 105 ,0, 120);

                g.Restore(gs);
            }
            for (int i = 1; i < 13; i++)
            {
                s = i.ToString();
                gs = g.Save();
                g.RotateTransform(30 * i);
                g.DrawString(s, Font, brush, -10, -100);

                g.Restore(gs);
            }
        }
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 300;
            this.Height = 350;
            this.Paint += From_Paint;
            timer1.Start();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            this.Invalidate();
        }
    }
}
