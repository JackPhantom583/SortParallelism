using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SortParallelism
{
    public partial class Form1 : Form
    {
        private int size;
        private int[] DirtArray;
        private Random rnd = new Random();
        private Sort S;

        Thread t1;

        Thread t2;

        Thread t3;
        public Form1()
        {
            InitializeComponent();
        }
        public void CreateArray(int size)
        {
            
            DirtArray = new int[size];
            for (int i = 0; i < DirtArray.Length; i++)
            {
                DirtArray[i] = rnd.Next(0, 9);
            }
            S = new Sort();
            t1 = new Thread(new ThreadStart(BubbleSortThread));
            t2 = new Thread(new ThreadStart(ShakerSortThread));
            t3 = new Thread(new ThreadStart(ShellSortThread));
        }
        public void OutputArray(TextBox tb,Label lb1,Label lb2,int[] mass,string st,int p)
        {

            if (tb.InvokeRequired)
            {
                lb1.Invoke(new Action(() => lb1.Text = st));
                lb2.Invoke(new Action(() => lb2.Text = p.ToString()));
                for (int i = 0; i < size; i++)
                {
                    tb.Invoke(new Action(() => tb.Text += mass[i]));
                }
                
            }
            for (int i = 0; i < size; i++)
            {
                Console.Write(mass[i]);
            }
            Console.WriteLine();
        }
        public void BubbleSortThread()
        {

            OutputArray(textBox1,label6,label11, S.BubbleSort(DirtArray),S.t,S.per);
        }
        public void ShakerSortThread()
        {
            OutputArray(textBox2,label8,label13, S.ShakerSort(DirtArray),S.t,S.per);
        }
        public void ShellSortThread()
        {
            OutputArray(textBox3,label10,label15, S.ShellSort(DirtArray),S.t,S.per);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            size = Convert.ToInt32(textBox4.Text);
            CreateArray(size);
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}
