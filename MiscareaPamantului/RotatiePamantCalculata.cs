using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiscareaPamantului
{
    public partial class RotatiePamantCalculata : Form
    {
        private int R1=400;
        private int R2=280;
        private int sx = 170, sy = 100;
        private double alpha = 0;
        private const long sM = 149590000;
        private const long sm = 147412577;
        double zile = 30;
        //1.03
        public RotatiePamantCalculata()
        {
            InitializeComponent();
        }

        private void RotatiePamantCalculata_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 1);
            g.DrawEllipse(pen, sx, sy, R1, R2);
            pictureBox1.Location = new Point((int)((sx + R1 / 2 - pictureBox1.Width/2)*1.03f), (int)((sy + R2 / 2 - pictureBox1.Height / 2)*1.03f));
            pictureBox2.Location = new Point((int)(R1/2 * Math.Cos((double)alpha)+pictureBox1.Location.X + pictureBox2.Width/2), (int)(R2/2 * Math.Sin((double)alpha))+pictureBox1.Location.Y+pictureBox2.Height/2);
            g.DrawLine(pen,new Point(pictureBox1.Location.X+pictureBox1.Width/2,pictureBox1.Location.Y+pictureBox1.Height/2), new Point(pictureBox2.Location.X+pictureBox2.Width/2,pictureBox2.Location.Y+pictureBox2.Height/2));
            g.Dispose();
           double xp = Math.Cos(alpha) * sM* 1.034013605442177;
           double xy= Math.Sin(alpha) * sm / 1.034013605442177;
          double distanta=Math.Sqrt(xp*xp+xy*xy);
            label1.Text=distanta.ToString();

            alpha += Math.PI / 200;
            if (zile <= 390)
            {
                zile += 0.915;
                int z, m;
                z = ((int)zile) % 30+1;
                m = ((int)zile/30) %12;
                switch (m) 
                {
                    case 0:
                        label2.Text = z.ToString() + " decembrie";
                        break;
                    case 1:
                        label2.Text = z.ToString() + " ianuarie";
                        break;
                    case 2:
                        label2.Text = z.ToString() + " februarie";
                        break;
                    case 3:
                        label2.Text = z.ToString() + " martie";
                        break;
                    case 4:
                        label2.Text = z.ToString() + " aprilie";
                        break;
                    case 5:
                        label2.Text = z.ToString() + " mai";
                        break;
                    case 6:
                        label2.Text = z.ToString() + " iunie";
                        break;
                    case 7:
                        label2.Text = z.ToString() + " iulie";
                        break;
                    case 8:
                        label2.Text = z.ToString() + " august";
                        break;
                    case 9:
                        label2.Text = z.ToString() + " septembrie";
                        break;
                    case 10:
                        label2.Text = z.ToString() + " octombrie";
                        break;
                    case 11:
                        label2.Text = z.ToString() + " noiembrie";
                        break;
                }
                   

            }
            else
            {
                zile = 30;
            }
        }
    }
}
