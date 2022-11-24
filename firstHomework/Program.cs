using System;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;

namespace Lesson_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //task1_1();
            //task1_2();
            //task1_4();// с помощью массива
            //task1_4_rec();// с помощью рекурсии
            //task2_1();
            //task2_2();
            //task2_3();
            //task2_5();
            //task3_1();
            //task3_2();
            //task3_3();
        }

        static void task1_1()
        {
            for (int i = 9; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        for (int l = k - 1; l >= 0; l--)
                        {
                            Console.WriteLine(i * 1000 + j * 100 + k * 10 + l);
                        }
                    }
                }
            }
        }

        static void task1_2()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        Console.Write(n + " ");
                    }
                    else if (j > i)
                    {
                        Console.Write((n - j + i) + " ");
                    }
                    else if (j < i)
                    {
                        Console.Write((n - i + j) + " ");
                    }
                }
                Console.WriteLine("");
            }
        }

        static void task1_4()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            arr[0, 0] = 1;
            Console.WriteLine(1);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0)
                    {
                        arr[i, j] = 1;
                    }
                    else
                    {
                        arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];
                    }
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine("");
            }
        }

        static void task1_4_rec()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(rec(i, j) + " ");
                }

                Console.WriteLine("");
            }
        }

        static int rec(int i , int j)
        {
            if (i == 0 || j == 0)
            {
                if (i == 0 && j != 0)
                {
                    return 0;
                }
                return 1;
            }
            return rec(i - 1, j - 1) + rec(i - 1, j);
        }

        static void task2_1()
        {
            int end = 0;
            int n = int.Parse(Console.ReadLine());
            int exmp = n;
            while (n > 0)
            {
                n /= 2;
                end++;
            }
            for (int i = end; i > 0; i--)
            {
                if ((exmp & (1 << i - 1)) != 0)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
            }
            
        }

        static void task2_2()
        {
            int end = 0;
            int n = int.Parse(Console.ReadLine()), m = int.Parse(Console.ReadLine());
            int exmp = n;
            n = n > m ? n : m;
            while (n > 0)
            { 
                n /= 2;
                end++;
            }
            for (int i = end; i > 0; i--)
            {
                if ((exmp & (1 << i - 1)) != 0)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
            }
            Console.WriteLine("");
            for (int i = end; i > 0; i--)
            {
                if ((m & (1 << i - 1)) != 0)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < end; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int i = end; i > 0; i--)
            {
                if ((exmp & (1 << i - 1) | m & (1 << i - 1)) != 0)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
            }
        }
        
        static void task2_3()
        {
            short x = short.Parse(Console.ReadLine()), y = short.Parse(Console.ReadLine()), z = short.Parse(Console.ReadLine()), w = short.Parse(Console.ReadLine());
            long res = x;
            res = res | ((long)y << 16) | ((long)z << 32) | ((long)w << 48);
            Console.WriteLine(res);
        }

        static void task2_5()
        {
            long n = long.Parse(Console.ReadLine());
            byte m = byte.Parse(Console.ReadLine()), k = byte.Parse(Console.ReadLine());
            k = m > k ? m : k;
            m = m > k ? k : m;
            long need = 1;
            for (int i = 0; i < 8; i++)
            {
                need *= 2;
            }
            need -= 1;
            long firstByte = n & (need << 8 * (m - 1));
            long secondByte = n & (need << 8 * (k - 1));
            n = n & ~(need << 8 * (m - 1));
            n = n & ~(need << 8 * (k - 1));
            n = n | (firstByte << 8 * (k - m)) | (secondByte >> 8 * (k - m));
            string str = Convert.ToString(n, 2);
            int len = str.Length;
            for (int i = 0; i < 64 - len; i++)
            {
                str = "0" + str;
            }
            
            for (int i = 0; i < 64; i++)
            {
                if (i % 8 == 0 && i != 0)
                {
                    Console.Write(" " + str[i]);
                }
                else
                {
                    Console.Write(str[i]);
                }
            }
        }

        static void task3_1()
        {
            string str = Console.ReadLine();
            int n = int.Parse(str.Split(' ')[0]), p = int.Parse(str.Split(' ')[1]);
            str = Console.ReadLine();
            double[] arr = print(str, n);
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += Math.Pow(arr[i], p);
            }
            double res = Math.Pow(sum, 1f / p);
            Console.WriteLine(res);
        }

        static void quick_sort(double[] arr,int begin,int end)
        {
            if (begin < end)
            {
                int devide = divideIndex(arr, begin, end);
                quick_sort(arr, devide, end);
                quick_sort(arr, begin, devide - 1);
            }
        }

        static int divideIndex(double[] arr,int begin, int end)
        {
            int leftInd = begin;
            int rightInd = end;
            double divide = arr[begin];
            while (leftInd <= rightInd)
            {
                while (arr[leftInd] < divide)
                {
                    leftInd++;
                }

                while (arr[rightInd] > divide)
                {
                    rightInd--;
                }

                if (leftInd <= rightInd)
                {
                    double dopMemory = arr[rightInd];
                    arr[rightInd] = arr[leftInd];
                    arr[leftInd] = dopMemory;
                    leftInd++;
                    rightInd--;
                }
            }
            return leftInd;
        }

        static void task3_2()
        {
            int count = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            double[] arr = print(str, count);
            int index = int.Parse(Console.ReadLine());
            quick_sort(arr, 0, count - 1);
            Console.WriteLine(arr[index - 1]);
        }

        static double[] print(string str, int len)
        {
            double[] arr = new double[len];
            string newStr = "";
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length - 1 == i)
                {
                    newStr += str[i];
                    arr[count] = double.Parse(newStr);
                    break;
                }
                if (str[i] == ' ')
                {
                    arr[count] = double.Parse(newStr);
                    count++;
                    newStr = "";
                    continue;
                }

                if (str[i] == '.')
                {
                    newStr += ',';
                    continue;
                }
                newStr += str[i];
            }

            return arr;
        }

        static void task3_3()
        {
            int len = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            double[] arr = print(str, len);
            str = Console.ReadLine();
            int begin = int.Parse(str.Split(':')[0]),
                end = int.Parse(str.Split(':')[1]),
                step = int.Parse(str.Split(':')[2]);
            double[] newArr = new double[0];
            int count = 0;
            if (step == 0)
            {
                Console.WriteLine("Chto to neponyatnoye");
            }
            else if (step < 0)
            {
                newArr = new double[(end - begin) / -step + 1]; 
                for (int i = end; i >= begin; i += step, count++)
                {
                    newArr[count] = arr[i];
                }
                foreach (double x in newArr)
                {
                    Console.Write(x + " ");
                }
            }
            else
            {
                newArr = new double[(end - begin) / step + 1]; 
                for(int i = begin; i <= end; i += step, count++)
                {
                    newArr[count] = arr[i];
                }
                foreach (double x in newArr)
                {
                    Console.Write(x + " ");
                }
            }
        }
    }
}