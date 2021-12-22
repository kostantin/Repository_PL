using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args) {         

            int n = 0; int m = 0;


            string[] read = Console.ReadLine().Split(' ');
            n = int.Parse(read[0]);
            m = int.Parse(read[1]);
            

            int[] array = new int[n];

            for (int i = 0; i < n; i++) {
                 
                int a = i;
                a++;
                array[i] = a;
            }

            List<int> list = new List<int>();
            int firstElement = 1;
            int step = 0;
            int interval = m - 1;
            int lenghtArr = n;
           

            for (int i = 0; i < lenghtArr; i++) {             

                if (step == 0) {
                    list.Add(array[i]);
                }

                if (step == interval) {
                    
                    if (array[i] == firstElement) {
                        i = lenghtArr;
                    }
                    i--;
                    step = 0;

                }else {
                    step++;

                    if (i == lenghtArr - 1) {
                        i = -1;
                    }
                } 
            }

            string concat = String.Join("", list.ToArray());

            Console.WriteLine("\n" + concat);

            
            Console.ReadKey(true);

        }   
    }
}
