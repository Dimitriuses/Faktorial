using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Faktorial
{
    class Program
    {
        public static List<string> Rezult = new List<string>();
        static void Main(string[] args)
        {
            
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(factorial);
            //int factend;
            //factend = Convert.ToInt32(Console.ReadLine());
            Thread thread = new Thread(threadstart);
            thread.Start((object)200);
            threadstart = new ParameterizedThreadStart(SimpleNumber);
            Thread thread1 = new Thread(threadstart);
            thread1.Start(50);
            threadstart = new ParameterizedThreadStart(fibonach);
            Thread thread2 = new Thread(threadstart);
            thread2.Start(50);
            //Console.WriteLine(factorial(factend));
            //SimpleNumber(50);
            //fibonach(50);
            Console.ReadKey();
            foreach (var item in Rezult)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static string to_pos(string multi1, char a)
        {
            int multi2 = Convert.ToInt32(a.ToString());
            int tmp = 0;
            int procesing = 0;
            string rez = "";
            string strtmp = "";
            for (int i = multi1.Length - 1; i >= 0; i--)
            {
                procesing = Convert.ToInt32(multi1[i].ToString());
                tmp += procesing * multi2;
                if(tmp >= 10 && i != 0)
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp % 10;
                    rez += strtmp;
                    tmp = tmp / 10;
                }
                else if(i == 0)
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp;
                    rez += strtmp;
                }
                else
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp;
                    rez += strtmp; 
                    tmp = 0;
                }

            }
            return rez;
        }

        private static string zero(int max)
        {
            string rez = "";
            for (int i = 0; i < max; i++)
            {
                rez += "0";
            }
            return rez;
        }
        
        private static string adding(string a,string b)
        {
            int tmp = 0;
            string rez = "";
            string strtmp = "";
            int zer = a.Length - b.Length;
            if (zer > 0)
            {
                strtmp = b;
                b = "";
                b += zero(zer);
                b += strtmp;
            }
            else if(zer < 0)
            {
                strtmp = a;
                a = "";
                a += zero(zer * -1);
                a += strtmp;
            }
            //Console.WriteLine(a,b);
            for (int i = a.Length - 1; i >= 0; i--)
            {
                tmp += Convert.ToInt32(a[i].ToString()) + Convert.ToInt32(b[i].ToString());
                if (tmp >= 10 && i != 0)
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp % 10;
                    rez += strtmp;
                    tmp = tmp / 10;
                }
                else if (i == 0)
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp;
                    rez += strtmp;
                }
                else
                {
                    strtmp = rez;
                    rez = "";
                    rez += tmp;
                    rez += strtmp;
                    tmp = 0;
                }
            }
            return rez;
        }

        private static string Multiplix( string a, string b)
        {
            string multi1 = a;
            string multi2 = b;

            int countM2 = multi2.Length;

            string rez = "0";
            string[] pos = new string[countM2];

            //Console.WriteLine(to_pos("8633",'4'));


            for (int i = countM2 - 1; i >= 0; i--)
            {
                pos[countM2 - i - 1] = to_pos(multi1, multi2[i]);
                //Console.WriteLine($"{multi1} * {multi2[i]} = {pos[countM2 - i - 1]} [{countM2 - i - 1}]");
            }
            for (int i = 0; i < countM2; i++)
            {
                pos[i] += zero(i);
                //Console.WriteLine($"[{i}] {pos[i]}");
            }
            //Console.WriteLine(adding("588","84245"));
            for (int i = 0; i < pos.Length; i++)
            {
                rez = adding(rez, pos[i]);
            }
            //Console.WriteLine(rez);
            //Console.ReadKey();
            return rez;
        }

        static void factorial(object a)
        {
            string rez = "1";
            for (int i = 1; i < (int)a; i++)
            {
                rez = Multiplix(rez, i.ToString());
            }
            //return rez;
            //Console.WriteLine(rez);
            Rezult.Add(rez);
        }

        static void SimpleNumber(object max)
        {
            
            //int tmp = 0;
            for (int i = 1; i < (int)max; i++)
            {
                int tmpI = 0;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                    else
                    {
                        tmpI++;

                    }
                }
                if (tmpI == i - 2 || i == 1) 
                {
                    //Console.WriteLine("S = "+i);
                    Rezult.Add("S = " + i);
                }
            }
        }
        static void fibonach(object max)
        {
            int i = 1;
            int tmp = 1;
            while (i < (int)max) 
            {
                int t = i;
                i = tmp + i;
                tmp = t;
                //Console.WriteLine("F = "+i);
                Rezult.Add("F = " + i);
            }
        }
    }
}
