using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiscareaPamantului
{
    public partial class SferaCereasca : Form
    {
        public SferaCereasca()
        {
            InitializeComponent();
        }
        int px=100,py=100,R1=300,R2=200;
        private double phi=0, phip=0;
        const double ex= 0.00763;
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            phi = Double.Parse(textBox1.Text);
            g.DrawEllipse(new Pen(Color.Black), px, py, R1, R2);
            g.DrawLine(new Pen(Color.Black), px, py + R2 / 2, px + R1, px + R2 / 2);
            g.DrawLine(new Pen(Color.Black), px + R1 / 2, py, px + R1 / 2, px + R2);
            Debug.WriteLine(Math.Cos(phi));
            g.DrawLine(new Pen(Color.Red), px + R1 / 2, py + R2 / 2, (int)((R1/2) * Math.Cos(phi)+ px + R1 / 2), (int)((R2/2) * Math.Sin(phi)+ py + R2 / 2));
            phip = -(1 / 2 * 206264.8 * ex * ex * Math.Sin(2 * phi) - phi);
            g.DrawLine(new Pen(Color.Green), px + R1 / 2 + 30, py + R2 / 2, (int)((R1 / 2) * Math.Cos(phip) + px + R1 / 2), (int)((R2 / 2) * Math.Sin(phip) + py + R2 / 2));
            g.Dispose();
         
        }

        private void SferaCereasca_Load(object sender, EventArgs e)
        {
            
        }

    }
}
