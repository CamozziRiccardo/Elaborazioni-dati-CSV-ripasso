using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elaborazioni_dati_CSV__ripasso
{
    public partial class Form1 : Form
    {
        funzioni f;

        public Form1()
        {
            f = new funzioni();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.Azione1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di campi presenti nel file CSV è: " + f.Azione2());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il campo più lungo ha " + f.Azione3() + " caratteri");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f.Azione4();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] split = textBox13.Text.Split();
            f.Azione5(textBox2.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, split[0] + "T" + split[1], textBox14.Text, textBox15.Text, textBox16.Text);
            groupBox1.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //f.Azione6();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = f.Azione7(textBox1.Text);
            if (i != -1)
            {
                MessageBox.Show("Elemento trovato alla riga" + i);
            }
            else
            {
                MessageBox.Show("Elemeneto non trovato");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string[] split = textBox17.Text.Split();
            f.Azione8(textBox22.Text, textBox21.Text, textBox20.Text, textBox19.Text, textBox18.Text, split[0] + "T" + split[1], textBox8.Text, textBox6.Text, textBox5.Text, textBox23.Text, textBox24.Text, int.Parse(textBox7.Text));
            groupBox1.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //f.Azione9(filename, delim, textBox3.Text, textBox4.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
        }
    }
}
