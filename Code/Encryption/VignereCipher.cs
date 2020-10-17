using System;
using System.Collections.Generic;
using static Code.Encryption.CaesarCipher;

namespace Code.Encryption
{
    class VignereCipher
    {
        public static string VignereEncode(string userInput, string key, bool decrypt)
        {
            var shifts = new List<int>();
            var characters = new List<char>();
            var counter = 0;
            var userInputCounter = 0;
            var s = ' ';
            //I iterate through the key and add how far each letter needs to be shifted to a 
            while (shifts.Count < userInput.Length)
            {
                s = key[counter]; 
                if (userInput[userInputCounter] != ' ')
                {
                    if (Convert.ToInt32(s) < 91 && Convert.ToInt32(s) > 64)
                    {
                        if (decrypt) shifts.Add((Convert.ToInt32(s)-65)*-1);
                        else shifts.Add(Convert.ToInt32(s)-65);
                    }
                    else if (Convert.ToInt32(s) > 96 && Convert.ToInt32(s) < 123)
                    {
                        if (decrypt) shifts.Add((Convert.ToInt32(s)-97)*-1);
                        else shifts.Add(Convert.ToInt32(s)-97);
                    }
                }
                else
                {
                    shifts.Add(0);
                    counter = mod(counter-1, key.Length);
                }
                counter = mod(counter+1, key.Length);
                userInputCounter = mod(userInputCounter+1, userInput.Length-1);
            }
            counter = 0;
            //Now I iterate through the input sending each character to my caesar encode function and providing the relevant shift
            foreach (var y in userInput)
            {
                characters.Add(Convert.ToChar(CaesarEncode(Convert.ToString(y), shifts[counter])));
                counter += 1;
            }
            return String.Join("", characters.ToArray());
        }
    }
}
        