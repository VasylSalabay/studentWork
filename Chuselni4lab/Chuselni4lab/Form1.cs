using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuselni4lab
{
    public partial class Form1 : Form
    {
        Integral integral= new Integral();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox6.Text);
            double eps = double.Parse(textBox7.Text);
            integral = new Integral(a,b,eps);
            textBox2.Text = integral.MethodLeftRectangle().ToString();
            textBox8.Text = integral.N.ToString();
            textBox12.Text = integral.CountOfFunction.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox6.Text);
            double eps = double.Parse(textBox7.Text);
            integral = new Integral(a, b, eps);
            textBox3.Text = integral.MethodTrapeciy().ToString();
            textBox9.Text = integral.N.ToString();
            textBox13.Text = integral.CountOfFunction.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox6.Text);
            double eps = double.Parse(textBox7.Text);
            integral = new Integral(a, b, eps);
            textBox5.Text = integral.MethodParabol().ToString();
            textBox10.Text = integral.N.ToString();
            textBox14.Text = integral.CountOfFunction.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox6.Text);
            double eps = double.Parse(textBox7.Text);
            integral = new Integral(a, b, eps);
            textBox4.Text = integral.MethodGaus().ToString();
            textBox11.Text = integral.N.ToString();
            textBox15.Text = integral.CountOfFunction.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox6.Text);
            double eps = double.Parse(textBox7.Text);
            integral = new Integral(a, b, eps);
            int k = 100;
            double h = (b - a) / k;
            chart1.Series[0].Points.Clear();
            for(int i=0;i<k;i++)
            {
                double x = a + i * h;
                double y = integral.F(x);
                chart1.Series[0].Points.AddXY(x, y);
            }

        }
    }
}
