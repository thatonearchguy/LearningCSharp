﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace BIO_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number: ");
            var userInput = Console.ReadLine().ToString();
            Console.WriteLine(FastPalindrome(userInput));
        }
        public static char[] NumToString(Int64 number)
        {
            return number.ToString().ToCharArray();
        }
        public static bool IsPalindrome(Int64 input)
        {
            while(true)
            {
                var numberArray = NumToString(input);
                var duplicatedArray = NumToString(input);
                Array.Reverse(numberArray);
                if(duplicatedArray.SequenceEqual(numberArray) == false) return false;
                else return true;
            }
        }
        public static Int64 FastPalindrome(string input)
        {
            var number = Convert.ToInt64(input)+1;
            var splitList = new List<int>();
            if (number<9) return number;
            else if (IsPalindrome(number) == true) return number;
            else
            {
                foreach(char i in number.ToString()) splitList.Add(Convert.ToInt32(i.ToString()));
                for (int i = 0; i < splitList.Count()/2; i ++)
                {
                    while (splitList[i] != splitList[splitList.Count()-1-i])
                    {
                        splitList[splitList.Count()-1-i] = (splitList[splitList.Count()-1-i] + 1)%10;
                    }
                }
            }
            return Int64.Parse(String.Join("", splitList));
        }
    }
}
