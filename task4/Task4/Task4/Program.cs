using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task4
{

    class MinStep
    {
        List<int> _list = new List<int>();

        List<int> steps = new List<int>();

        public List<int> SetList(List<int> list) {
            _list = list;

            return GetStep();
        }

        private List<int> GetStep() {

            for (int i = 0; i < _list.Count; i++) {

                ArraySplit arraySplit = new ArraySplit();

                int step = arraySplit.Start(i, _list);

                steps.Add(step);
            }
            return steps;
        }

    }

    class ArraySplit
    {
        List<int> cloneList = new List<int>();

        int _compareNum;

        public int Start(int index, List<int> list) {

            CloneList(list);

            RemoveIndexFormList(index);

            ArrayCheck arrayCheck = new ArrayCheck();

            int steps = arrayCheck.GetSteps(cloneList, _compareNum);

            return steps;
        }

        private void RemoveIndexFormList(int index) {

            _compareNum = cloneList[index];


            cloneList.RemoveAt(index);
        }

        private void CloneList(List<int> list) {

            foreach (var item in list) {

                cloneList.Add(item);
            }
        }
    }

    class ArrayCheck
    {
        List<int> _list = new List<int>();

        int _compareNum;

        int stepsCount;

        public int GetSteps(List<int> list, int compareNum) {

            _list = list;

            _compareNum = compareNum;

            for (int i = 0; i < _list.Count; i++) {

                CheckNum checkNum = new CheckNum();

                int steps = checkNum.Check(_compareNum, _list[i]);

                stepsCount += steps;
            }

            return stepsCount;
        }
    }

    class CheckNum
    {
        int step = 0;

        int number;

        int compare;

        public int Check(int numCompare, int num) {

            number = num;

            compare = numCompare;

            while (Checking()) {

                step++;
            }

            return step;
        }

        private bool Checking() {

            if (number < compare) {
                number++;
                return true;
            }

            if (number > compare) {
                number--;
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args) {

            string n;
           // Console.WriteLine("Set Nums and then press Enter\n");
            n = Console.ReadLine();

            List<int> nums = new List<int>();

            foreach (string line in File.ReadLines(n)) {
                int num = Convert.ToInt32(line);
                nums.Add(num);
            }



            MinStep minStep = new MinStep();

            List<int> steps = new List<int>();

            steps = minStep.SetList(nums);

            int min = steps.Min();
            
            Console.WriteLine("\n" + min);

            Console.ReadKey(true);

        }
    }
}
