using System;
using System.Linq;
using System.Collections.Generic;

namespace BIO_Exercises
{
    class Program2
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number: ");
            var userInput = Console.ReadLine().ToString();
            Console.WriteLine(NewOrder(userInput));
        }
        public static List<Int64> NewOrder(Int64 n, Int64 m)
        {
            var worklist = new List<Int64>();
            for (int i = 0; i < m; i ++) worklist.Add(1);
            if (n > 1){
                if (worklist.Count() == 1) worklist.Add(0);
                else worklist.Insert(1, 0);
                
            }
            else{
                return worklist;
            }

        }

    }
}