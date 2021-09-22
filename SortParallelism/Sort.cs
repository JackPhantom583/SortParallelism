using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortParallelism
{
    class Sort
    {
        public string kindsort;
        public string t;
        public int per;
        
        public int[] BubbleSort(int[] ar)
        {
            var sw = new Stopwatch();
            sw.Start();
            int[] array = new int[ar.Length];
            Array.Copy(ar, array, ar.Length);
            kindsort = "bubble";
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        per++;
                    }
                }
            }
            sw.Stop();
            t = sw.Elapsed.ToString();
            return array;
        }
        public int[] InsertSort(int[] ar)
        {
            var sw = new Stopwatch();
            sw.Start();
            int[] array= new int[ar.Length];
            Array.Copy(ar, array, ar.Length);
            kindsort = "insert";
            int len = array.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            return array;
            sw.Stop();
            t = sw.Elapsed.ToString();
            return array;
        }
        public int[] ShellSort(int[] ar)
        {
            var sw = new Stopwatch();
            sw.Start();
            int[] array = new int[ar.Length];
            Array.Copy(ar, array, ar.Length);
            kindsort = "shell";
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j-d] > array[j]))
                    {
                        int temp = array[j];
                        array[j] = array[j - d];
                        array[j - d] = temp;
                        j = j - d;
                        per++;
                    }
                }

                d = d / 2;
            }
            sw.Stop();
            t = sw.Elapsed.ToString();
            return array;
        }
    }
}
