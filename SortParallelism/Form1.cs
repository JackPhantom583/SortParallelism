using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortParallelism
{
    public partial class Form1 : Form
    {
        private int size;
        private int[] DirtArray;
        private int[] ClearArray;
        private Random rnd = new Random();
        private Sort S;


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
            S = new Sort(DirtArray);
        }
        public void OutputArray()
        {
            
            Array.Copy(DirtArray, ClearArray, size);
            for (int i = 0; i < size; i++)
            {
                if (S.kindsort == "bubble")
                {
                    textBox1.Text += ClearArray[i].ToString();
                }
                else if (S.kindsort == "shaker")
                {
                    textBox2.Text += ClearArray[i].ToString();
                }
                else if (S.kindsort == "shell")
                {
                    textBox3.Text += ClearArray[i].ToString();
                }
                Console.Write(ClearArray[i]);
            }
            Console.WriteLine();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            size = Convert.ToInt32(textBox4.Text);
            ClearArray = new int[size];
            CreateArray(size);
            S.BubbleSort();
            OutputArray();
            S.ShakerSort();
            OutputArray();
            S.ShellSort();
            OutputArray();
        }

        
    }
}
