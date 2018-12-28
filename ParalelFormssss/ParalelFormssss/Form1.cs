using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParalelFormssss
{
    public partial class Form1 : Form
    {
        public delegate void NumOfAdditionalWindowsChange();
        public event NumOfAdditionalWindowsChange PlusOneWindow;
        public event NumOfAdditionalWindowsChange MinusOneWindow;
        int numOfAdditionalwindows = 0;
        List<Form2> windows;
        Form2 lastWindow;
        public Form1()
        {
            InitializeComponent();
            windows = new List<Form2>();
            textBox1.Text = numOfAdditionalwindows.ToString();
            PlusOneWindow += AddWindow;
            MinusOneWindow += DeleteWindow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AddWindow()
        {
            numOfAdditionalwindows++;
            textBox1.Text = numOfAdditionalwindows.ToString();
           
        }
        private void DeleteWindow()
        {
            numOfAdditionalwindows--;
            textBox1.Text = numOfAdditionalwindows.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lastWindow = new Form2(this);
            windows.Add(lastWindow);
            lastWindow.Show();
            PlusOneWindow?.Invoke();
            

        }
        public void AdditionalWindowClosed()
        {
            MinusOneWindow?.Invoke();
        }
    }
}
