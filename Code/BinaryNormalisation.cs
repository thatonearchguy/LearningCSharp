using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    class BinaryNormalisation
    {
        /*
        static void Main(string[] args)
        {
            int mantissaBits = 0;
            int exponentBits = 0;
            bool validInput = false;
            Console.Write("Enter the binary mantissa and exponent: ");
            List<char> binaryList = new List<char>((Convert.ToString(Console.ReadLine()).ToCharArray()).ToList());
            Console.Write("Enter the number of bits assigned to mantissa: ");
            while (validInput == false){
                try {
                    mantissaBits = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the number of bits assigned to the exponent: ");
                    exponentBits = Convert.ToInt32(Console.ReadLine());
                    if ((exponentBits + mantissaBits - 1) == binaryList.Count){
                        throw new FormatException("mantissa and exponent bits invalid.");
                    }
                    else{
                        validInput = true;
                    }
                }
                catch {
                    Console.WriteLine("Invalid input! Please try again.");
                }
            }
            List<char> mantissaList = new List<char>(binaryList.Take(mantissaBits));
            string userExponent = binaryList.Skip(mantissaBits).Take(exponentBits).ToString();
            Console.WriteLine(mantissaList.Count());
            Console.WriteLine(userExponent.Count());
            Console.WriteLine(TheNormaliser(mantissaList, userExponent));
        }
        */

        public static string TheNormaliser(List<char> mantissa, string exponent){
            //This function normalises floating point numbers. It is the normaliser. Normaliser of binary point numbers. 
            int exponentDecrement = 0;
            char binaryPoint = mantissa[0];
            while(true){
                if (binaryPoint == mantissa[1])
                {
                    mantissa.RemoveAt(1);
                    exponentDecrement += 1;
                    mantissa.Add('0');
                }
                else break;
            }
            return $"{mantissa.ToString()}{SignedBinarySubtractor(exponent, exponentDecrement).ToString()}";
        }
        public static string SignedBinarySubtractor(string funcexponent, int decrementAmount){
            int workingBinary = Convert.ToInt32(funcexponent, 2) - decrementAmount;
            return Convert.ToString(workingBinary, 2).Substring(27, 5);
        }
    }
}