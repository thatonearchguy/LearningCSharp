using System;
using System.Collections.Generic;

namespace Code.Functions
{
    class Week3Functions
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(3, 4));
            Console.WriteLine(SumDigits(32456239));
            Console.WriteLine(IsPrime(7883));
            Console.WriteLine(Spaces("T h  i s is a STRANGE test st r    i n g"));
            int x = 5; 
            int y = 10;
            SwapTwo(ref x,ref y);
            Console.WriteLine($"x = {x} y = {y}");
            Console.WriteLine(BinaryHex(394832));
        }

        public static int Sum(int x, int y) {return x+y;}
        /*public static int Sum(int x, int y) {return (x * 2) + (y * 2);}*/
        public static int SumDigits(int x){
            string Joe = Convert.ToString(x);
            double Mama = 0;
            //Iterating through elements in string, converting to numbers and adding them together
            foreach (char i in Joe) Mama += Char.GetNumericValue(i);
            //Since GetNumericValue returns doubles, need to convert this back into an integer to avoid tonnnes of unnecessary decimal points
            return Convert.ToInt32(Mama);
        }

        public static bool IsPrime(int x){
            //Goes from i = 3 as all prime numbers are divisble by 1, and any number beyond root of the input is just a multiple of a different number - saving computational power. 
            for (int i = 3; i <= Math.Pow(x, 0.5); i += 2){
                if (x % i == 0) return false;
            }
            return true;
        }

        public static int Spaces(string x){
            int space = 0;
            //Similar to SumDigits - except it's already in a string which it can iterate through. 
            foreach (char i in x) 
            if (i == ' ') space += 1;
            return space;
        }

        public static void SwapTwo(ref int x, ref int y){
            //Takes ref of integers - so modifying the actual memory locations. 
            int placeholder = x;
            x = y;
            y = placeholder;
        }
        static string BinaryHex(int x){
            //Using some very nice string manipulation to convert to base2 and base 16. 
            return $"Bin: {Convert.ToString(x, 2)}, Hex: {x.ToString("X")}";
        }
        public static List<int> ShellSort(List<int> inputList){
            int workInt = 0;
            int counter = 0;
            for (int interval = inputList.Count/2; interval > 0; interval /= 2)
            for(int i = interval; i < inputList.Count; i++){
                workInt = inputList[i];
                for (counter = i; counter >= interval && inputList[counter-interval] > workInt; counter -= interval){
                    inputList[counter] = inputList[counter - interval];
                }
                inputList[counter] = workInt;                      
            }
            return inputList;
        }
        /*
        static string MayanCalendar(string MayanDate){
            List<string> calendarArray = new List<string>(MayanDate.Split(" "));
            List<string> referenceArray = new List<string>("13 20 7 16 3".Split(" "));
            bool done = false;
            while (done == false){
                
            }
        */

    }
}