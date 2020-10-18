using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    class BinaryNormalisation
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the binary number: ");
            var BinaryNumber = Console.ReadLine().ToString().ToCharArray();
            Console.Write("How many bits is the mantissa represented by? ");
            int MantissaBits = int.Parse(Console.ReadLine());
            var MantissaList = BinaryNumber.Take(MantissaBits);
            var exponentString = String.Join("", BinaryNumber.Skip(MantissaBits));
            Console.WriteLine(exponentString.Count());
            Console.WriteLine(MantissaList.Count());
            Console.WriteLine(TheNormaliser(MantissaList.ToList(), exponentString));
        }

        public static string TheNormaliser(List<char> mantissa, string exponent){
            //This function normalises floating point numbers. It is the normaliser. Normaliser of binary point numbers. 
            int exponentDecrement = 0;
            char binaryPoint = mantissa[0];
            while(true){
                if (binaryPoint == mantissa[1])
                {
                    mantissa.Add('0');
                    mantissa.RemoveAt(1);
                    exponentDecrement += 1;
                    
                }
                else break;
            }
            return $"{String.Join("", mantissa.ToArray())}{SignedBinarySubtractor(exponent, exponentDecrement).ToString()}";
        }
        public static string SignedBinarySubtractor(string funcexponent, int decrementAmount){
            int workingBinary = Convert.ToInt32(funcexponent, 2) - decrementAmount;
            return Convert.ToString(workingBinary, 2);
        }
    }
}