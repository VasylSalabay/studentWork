using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace LastHugeProgram
{
    public partial class Form1 : Form
    {
        int activeCountRow = 0; //
        string activeFileName;
        public Form1()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 20;
            dataGridView1.Columns[0].HeaderText = "Surname";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Group";
            dataGridView1.Columns[3].HeaderText = "AvarageMark";
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.activeFileName = openFileDialog1.FileName;
                this.Text = openFileDialog1.FileName+"*";
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string s = null;
                int i = 0;
                while((s=sr.ReadLine())!=null)
                {
                    Student student = new Student();
                    student.Parse(s);
                    dataGridView1[0, i].Value = student.Surname; 
                    dataGridView1[1, i].Value = student.Name;
                    dataGridView1[2, i].Value = student.Group;
                    dataGridView1[3, i].Value = student.EverageMark.ToString();
                    i++;
                }
              
                activeCountRow = i-1;
                sr.Close();
            }
           
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(this.Text.CompareTo("FileName.*")==0)
            {
                MessageBox.Show("не вибрана папка"); 
            }
            else
            {
                this.Text = activeFileName;
                StreamWriter sw = new StreamWriter(this.activeFileName);
                for(int i=0; i <= activeCountRow;i++)
                {
                    Student student = new Student();
                    student.Surname = dataGridView1[0, i].Value.ToString();
                    student.Name = dataGridView1[1, i].Value.ToString();
                    student.Group = dataGridView1[2, i].Value.ToString();
                    student.EverageMark = double.Parse(dataGridView1[3, i].Value.ToString()); // датагрідвю номер - доступ до комірки, . велюе шоб бачили текст але це обєкт і ми переводим в стрінг а потім парсим
                    sw.WriteLine(student.ToString()); // наформували і тепер записуєм у файл

                }
                sw.Close();
            }
        }

        private void sAVEASToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                this.Text = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName); 
                for (int i = 0; i <= activeCountRow; i++)
                {
                    Student student = new Student();
                    student.Surname = dataGridView1[0, i].Value.ToString();
                    student.Name = dataGridView1[1, i].Value.ToString();
                    student.Group = dataGridView1[2, i].Value.ToString();
                    student.EverageMark = double.Parse(dataGridView1[3, i].Value.ToString());
                    sw.WriteLine(student.ToString());

                }
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activeCountRow++; 
            if(dataGridView1.RowCount<activeCountRow)
            {
                MessageBox.Show("ви вичерпали ліміт таблиці!");
                return;

            }
            
            Form2 form2 = new Form2(dataGridView1,ref activeCountRow);
            
            form2.Owner = this;
            form2.Show();
            
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            DataGridViewSelectedRowCollection dc = dataGridView1.SelectedRows; 
            if(dc.Count<=0)
            {
                MessageBox.Show("ви не виділили рядочок");
                  return;
            }
            try
            {


                student.Surname = dc[dc.Count -1].Cells[0].Value.ToString(); 
                student.Name = dc[dc.Count - 1].Cells[1].Value.ToString();
                student.Group = dc[dc.Count - 1].Cells[2].Value.ToString();
                student.EverageMark = double.Parse(dc[dc.Count - 1].Cells[3].Value.ToString());
                Form2 form2 = new Form2(student, dc); 
                form2.Show();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true) 
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync(); 
            }
            //    button1.Enabled = false; // zaboron9em minytu shos na formi
            //    button2.Enabled = false;
            //    double sum = 0;

            //    progressBar1.Minimum = 0;
            //    progressBar1.Maximum = activeCountRow;
            //    progressBar1.Step = 1;

            //    for (int i = 0; i <= activeCountRow; i++)
            //    {
            //        sum += Convert.ToDouble(dataGridView1[3, i].Value.ToString());

            //        progressBar1.PerformStep();

            //       // label1.Text = "Value = " + progressBar1.Value.ToString();
            //        this.Update();
            //        Thread.Sleep(50);

            //    }
            //    sum = sum / activeCountRow;
            //    MessageBox.Show("EvarageMarkAllStudents" + sum);
            //    button1.Enabled = true; // zaboron9em minytu shos na formi
            //    button2.Enabled = true;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //for (int i = 1; i <= ; i++)
            //{
            //    if (worker.CancellationPending == true)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        System.Threading.Thread.Sleep(500);
            //        worker.ReportProgress(i * 10);
            //    }
            //}
            button1.Enabled = false; 

                                         button2.Enabled = false;
           // button4.Enabled = false;
            
                                     double sum = 0;

            progressBar1.Minimum = 0; 
            progressBar1.Maximum = activeCountRow;
            progressBar1.Step = 1;

            for (int i = 0; i <= activeCountRow; i++)
            {
                sum += Convert.ToDouble(dataGridView1[3, i].Value.ToString());

                progressBar1.PerformStep(); 

                // label1.Text = "Value = " + progressBar1.Value.ToString();
                this.Update();
                worker.ReportProgress(i * 10);
                Thread.Sleep(3000);

            }
            activeCountRow++;
            sum = sum / activeCountRow;
            MessageBox.Show("EvarageMarkAllStudents" + sum);
            button1.Enabled = true; 
            button2.Enabled = true;
           // button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) 
        {
           // label1.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.PerformStep();

                  // label1.Text = "Value = " + progressBar1.Value.ToString();
                    this.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label1.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label1.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label1.Text = "Done!";
            }
            progressBar1.Value = 0;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dc = dataGridView1.SelectedRows; 
            if(dc.Count==0)
            {
                MessageBox.Show("не виділений рядок для знищення");
            }
            this.activeCountRow -= dc.Count;
            foreach(var r in dc)
            {
                dataGridView1.Rows.Remove(r as DataGridViewRow);
            }
        }
    }
}
        
   

