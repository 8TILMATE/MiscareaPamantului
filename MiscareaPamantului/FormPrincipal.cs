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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var next = new RotatiePamantCalculata();
            this.Hide();
            next.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var next = new SistemSolar_MiscariDeRevolutie();
            this.Hide();
            next.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var next = new PunctulDeNuantie();
            this.Hide();
            next.ShowDialog();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var next = new SferaCereasca();
            this.Hide();
            next.ShowDialog();
            this.Close();
        }
    }
}
