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
    public partial class SistemSolar_MiscariDeRevolutie : Form
    {
        public static List<double> timpiderevolutie = new List<double>()
        {
            0.24,0.62,1,1.88,12,29,84,165
        };
        public static List<double> razamica = new List<double>();
        public static List<double> razamare = new List<double>();
        public static List<double> R1 = new List<double>();
        public static List<double> R2 = new List<double>();
        private static List<long> semiaxamare= new List<long>();
        private static List<long> semiaxamica = new List<long>();
        private static List<double> unghiuri = new List<double>();
        private static List<PictureBox> pictureBoxes = new List<PictureBox>();
        private double e= 0.17;
        private long timp;

        public SistemSolar_MiscariDeRevolutie()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void SistemSolar_MiscariDeRevolutie_Load(object sender, EventArgs e)
        {
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);



            foreach (var y in timpiderevolutie)
            {
                razamare.Add(0);
                razamica.Add(0);
            }
            razamare[2] = 1;
            for(int i = 0; i < razamare.Count; i++)
            {
                if (i != 2)
                {
                    double pr =(timpiderevolutie[i] * timpiderevolutie[i]);
                    double afterpr = (pr * Math.Pow(razamare[2], 3));
                    razamare[i] =Math.Pow(afterpr,1.0/3.0);
                    razamica[i] = getSemiAxisSmall(razamare[i]);
                }
                if (i == 2)
                {
                    razamica[i] = getSemiAxisSmall(razamare[i]);
                }
            }
            R1.Add(100);
            R2.Add(200);
            unghiuri.Add(0);
            for(int i = 1; i < razamare.Count; i++)
            {
                unghiuri.Add(0);
                semiaxamare.Add((long)(razamare[i] * 149000000));
                semiaxamica.Add((long)(razamica[i] * 149000000));
                R1.Add((razamica[i] / razamica[0]) * R1[0]);
                R2.Add((razamare[i] / razamare[0]) * R2[0]);

            }

        }
    
        private double  getSemiAxisSmall(double axamare)
        {
            return axamare * Math.Sqrt(1 - e * e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timp++;
            for(int i = 0; i < razamare.Count; i++)
            {
                if ((timp / timpiderevolutie[i] >= 1))
                {
                    unghiuri[i] += Math.PI / 200;
                    pictureBoxes[i].Location = new Point((int)(R2[i] / 2 * Math.Cos((double)unghiuri[i]) + pictureBox1.Location.X + pictureBoxes[1].Width / 2), (int)(R1[i] / 2 * Math.Sin((double)unghiuri[i])) + pictureBox1.Location.Y + pictureBoxes[1].Height / 2);
                }
            }
        }
    }
}
