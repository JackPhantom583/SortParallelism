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
        
        public int[] BubbleSort(int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();
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
        public int[] ShakerSort(int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();
            int[] ar = array;
            kindsort = "shaker";
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapFlag = true;
                        per++;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapFlag = true;
                        per++;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
            sw.Stop();
            t = sw.Elapsed.ToString();
            return array;
        }
        public int[] ShellSort(int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();
            int[] ar = array; ;
            kindsort = "shell";
            var d = array.Length / 2;
            while (d > 0)
            {
                for (var i = 0; i < (array.Length - d); i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j] > array[j + d]))
                    {
                        int temp = array[j];
                        array[j] = array[j + d];
                        array[j + d] = temp;
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
