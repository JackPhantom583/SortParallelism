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
        public void OutputArray(TextBox tb,int[] mass)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(mass[i]);
            }
            Console.WriteLine();
        }
        public void BubbleSortThread()
        {
            OutputArray(textBox1, S.BubbleSort(DirtArray));
        }
        public void ShakerSortThread()
        {
            OutputArray(textBox2, S.ShakerSort(DirtArray));
        }
        public void ShellSortThread()
        {
            OutputArray(textBox3, S.ShellSort(DirtArray));
        }




        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            size = Convert.ToInt32(textBox4.Text);
            CreateArray(size);
            t1.Start();
            //OutputArray();
            t2.Start();
            //OutputArray();
            t3.Start();
            //OutputArray();
        }

        
    }
}
