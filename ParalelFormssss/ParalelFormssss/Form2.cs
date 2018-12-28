using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ParalelFormssss
{
    public partial class Form2 : Form
    {
        Random randomiser = new Random();
        int valueToShow = 0;
        Thread generateThread;
        Form1 windowFather;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 father)
        {
            InitializeComponent();
            generateThread = new Thread(new ThreadStart(GenerateAndShow));
            generateThread.Start();
            windowFather = father;
        }
        private void GenerateAndShow()
        {
            do
            {
                valueToShow = randomiser.Next(1, 1000000);
                if (this != null)
                {
                    Invoke((Action)delegate
                    {

                        textBox1.Text = valueToShow.ToString();
                    });
                }
                Thread.Sleep(500);
            } while (true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (generateThread.ThreadState == ThreadState.Suspended)
            {
                generateThread.Resume();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateThread.Suspend();
        }
        private void ThreadWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            windowFather.AdditionalWindowClosed();
        }

        private void ThreadWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            generateThread.Suspend();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
