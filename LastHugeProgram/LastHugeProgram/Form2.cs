using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastHugeProgram
{
    public partial class Form2 : Form
    {
        DataGridView dt;
        int activeRow;
        Student s;
        DataGridViewSelectedRowCollection dc;
        bool isChange = false; // 
        public Form2()
        {
            InitializeComponent();
            isChange = false;
        }
        public Form2(DataGridView dt, ref int activeRow) 
        {

            InitializeComponent();
            this.dt = dt;
            this.activeRow = activeRow;
            s = null;
            isChange = false;
        }
        public Form2(Student s,  DataGridViewSelectedRowCollection dc)
        {
            InitializeComponent();
            //this.dt = dt;
           // this.activeRow = activeRow;
            this.s = s;
            this.dc = dc;
            textBox1.Text = s.Surname;
            textBox2.Text = s.Name;
            textBox3.Text = s.Group;
            textBox4.Text = s.EverageMark.ToString();
            isChange = true;
            

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double d = 0;
                if (!double.TryParse(textBox4.Text, out d))
                {
                    
                
                
                
                    throw new Exception("неправильний формат числа,введіть ще раз");
                }
                Student s = new Student(textBox1.Text, textBox2.Text, textBox3.Text, double.Parse(textBox4.Text));
                try
                {
                    if (!isChange)
                    {




                        dt[0, activeRow].Value = s.Surname;
                        dt[1, activeRow].Value = s.Name;
                        dt[2, activeRow].Value = s.Group;
                        dt[3, activeRow].Value = s.EverageMark.ToString();

                    }

                    else
                    {


                        dc[dc.Count - 1].Cells[0].Value = s.Surname;
                        dc[dc.Count - 1].Cells[1].Value = s.Name;
                        dc[dc.Count - 1].Cells[2].Value = s.Group;
                        dc[dc.Count - 1].Cells[3].Value = s.EverageMark.ToString();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
