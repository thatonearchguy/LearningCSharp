using System;
using System.Collections.Generic;

namespace Code.Encryption
{
    class CaesarCipher
    {
        public static int mod(int x, int m){return (x%m + m)%m;}
        public static string CaesarEncode(string userInput, int shift)
        {
            var WorkArray = new List<char>();
            //Iterating through user's input
            foreach (char s in userInput)
            {
                //Cases for when the shifting is not necessary like with a space
                if (s == ' ') WorkArray.Add(' ');
                //Conditions for when there is an overflow causing the output to have symbols. 
                else if (Convert.ToInt32(s) < 91 && Convert.ToInt32(s) > 64) WorkArray.Add(Convert.ToChar(mod((Convert.ToInt32(s)-65+shift),26)+65));
                else if (Convert.ToInt32(s) > 96 && Convert.ToInt32(s) < 123) WorkArray.Add(Convert.ToChar(mod((Convert.ToInt32(s)+shift-97),26)+97));
                else WorkArray.Add(Convert.ToChar(Convert.ToInt32(s)+shift));
            }
            //This is why I love lists, so nice to work with. I'm turning the list into an array and using a built in function to convert this into a string.
            //On .NET versions later than 4 it is possible to omit the ToArray() function. 
            return String.Join("", WorkArray.ToArray());
        }
    }
}