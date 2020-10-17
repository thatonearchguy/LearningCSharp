using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Iteration
{
    class Week3Iteration
    {

        /// <summary>
        /// This function will cleanly output a right justified times table for a set multiplier and number of rows!
        /// </summary>
        /// <param name="multiplier">What times table you want e.g 4x times table</param>
        /// <param name="rows">How far you want to go, e.g 12x4 or 20x4.</param>
        static void timesTable(int multiplier, int rows)
        {
            for (int i = 1; i <= rows; i ++)
            {
                Console.CursorLeft = Console.BufferWidth - ($"{i} x {multiplier} = {i*multiplier}".Length);
                Console.WriteLine($"{i} x {multiplier} = {i*multiplier}");
            }

        }
        /// <summary>
        /// Generates the total of n numbers and gives their average.
        /// </summary>
        /// <param name="n">How many numbers to input</param>
        static void Ask10(int n)
        {
            double[] numbers = new double[n];
            double total = 0;
            for (int i = 0; i < n; i++){
                Console.Write($"Enter number {i}: ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());
            }
            foreach (double num in numbers) total += num;
            Console.WriteLine($"Total = {Math.Round(total, 3)}, Average = {Math.Round(total/n)}");
        }
        /// <summary>
        /// Simple function which implements the triangular number formula
        /// n(n+1)/2
        /// </summary>
        /// <param name="n">What index to calculate for</param>
        /// <returns></returns>
        static int Triangular(int n){
            int triangularreturn = (((n+1)*n)/2);
            return triangularreturn;
        }
        /// <summary>
        /// Little function using string manipulation to calculate the total according to the ISBN algorithm, then modulus by 11 to find the missing number
        /// </summary>
        /// <param name="isbninput">10 digit string with integers and one '?' to denote the missing number</param>
        /// <returns></returns>
        static int ISBN(string isbninput){
            int total = 0;
            int unknownindex = 0;
            for (int i = 0; i < 10; i ++){
                if (isbninput[i] != '?') total += (10-i)*Convert.ToInt32(isbninput[i]);
                else unknownindex = i;
            }
            int remainder = 11-(total % 11);
            return remainder/unknownindex+1;
        }
        /// <summary>
        /// Counts how far Count Von Count from Sesame Street can count up to on his twitter feed.
        /// </summary>
        /// <param name="ands">Include ands in numbers? e.g one hundred and ... = true</param>
        /// <param name="commas">Include commas in numbers?</param>
        /// <param name="oldTwitter">Is Count Von Count from Sesame Street a Twitter purist? Hit true if he hates the 280char limit</param>
        /// <param name="valediction">Ahs?</param>
        /// <returns>Integer value of the highest number Count Von Count can count up to</returns>
        static int CountVonCount(bool ands, bool commas, bool oldTwitter, bool valediction){
            Dictionary<int, string> numbers = new Dictionary<int, string>(){
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
                {20, "twenty "},
                {30, "thirty "},
                {40, "fourty "},
                {50, "fifty "},
                {60, "sixty "},
                {70, "seventy "},
                {80, "eighty "},
                {90, "ninety "},
                {100, "one hundred "} };
            int characterCount = 0;
            int limit = 0;
            int counter = 0;
            if (oldTwitter == true) limit = 280;
            else limit = 140;
            while (characterCount < limit){
                counter ++;
                characterCount += numberGenerator(numbers, counter, ands, commas, valediction);
            }
            return counter - 1;
        }
        /// <summary>
        ///  YOU SHOULD NOT BE USING THIS FUNCTION. IT IS A HELPER FUNCTION FOR COUNTVONCOUNT()
        /// </summary>
        /// <param name="numberdict">Dictionary of numbers</param>
        /// <param name="number">Number required to represent</param>
        /// <param name="ands">Same options as CountVonCount function.</param>
        /// <param name="commas"></param>
        /// <param name="valediction"></param>
        /// <returns></returns>
        static int numberGenerator(Dictionary<int, string> numberdict, int number, bool ands, bool commas, bool valediction){
            int hundreds = 0;
            int remainder = 0;
            int tenremainder = 0;
            int tens = 0;
            int ones = 0;
            int total = 0;
            if (number <= 20){
                return numberdict[number].Length;
            }
            else {
                if (number > 100){
                    remainder = number % 100;
                    tenremainder = remainder % 10;
                    hundreds = number - remainder;
                    tens = remainder - tenremainder;
                    ones = tenremainder;
                    total += numberdict[hundreds].Length;
                    total += numberdict[tens].Length;
                    total += numberdict[ones].Length;
                    if (ands == true) total += 4;
                    if (commas == true) total += 1;
                }
                else{
                    remainder = number % 10;
                    tens = number - remainder;
                    ones = remainder;
                    total += numberdict[tens].Length;
                    total += numberdict[ones].Length;
                }
            }
            if (valediction == true) total += 11;
            return total;
        }

        /// <summary>
        /// Calculates the first value which is doubled after bringing the end digit to the start.
        /// </summary>
        /// <returns>Integer value</returns>
        static int doublingInt(){
            bool done = false;
            int workInt = 12;
            int flippedInt = 0;
            while (done == false){
                List<char> splitArray = (Convert.ToString(workInt).ToCharArray()).ToList();
                splitArray.Insert(0, splitArray[(splitArray.Count)-1]);
                splitArray.RemoveAt(splitArray.Count-1);
                flippedInt = Convert.ToInt32(splitArray.ToString());
                if (flippedInt / workInt == 2) return workInt;
                else workInt += 1;
            }
            return 0; 
        }
    }
}