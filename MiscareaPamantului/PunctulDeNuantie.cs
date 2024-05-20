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
    
    public partial class PunctulDeNuantie : Form
    {
        private double miu, lambda;
        private const double c1 = -17.23, c2 = 9.21;
        public PunctulDeNuantie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miu = Double.Parse(textBox2.Text);
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Point[] p = new Point[20];
            for(int i=0; i<20; i++)
            {
                p[i]=new Point(i*5+200,(int)FunctieGrafica(i*5)+200);
            }
            g.DrawCurve(new Pen(Color.Black), p);
            g.DrawLine(new Pen(Color.Red),new Point(200,200),new Point(200,400));
            g.DrawLine(new Pen(Color.Red), new Point(200, 400), new Point(400, 400));
            g.Dispose();
        }
        private double FunctieGrafica(double x)
        {
            double num = Math.Abs((17.23 * Math.Sin(miu)));
            return 9.21 * Math.Sqrt(1 + (x*x) / num);
        }
    }
}
